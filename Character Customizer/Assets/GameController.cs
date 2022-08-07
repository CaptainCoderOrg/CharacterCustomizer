using System.Collections;
using System.Collections.Generic;
using Firebase.Database;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    async void Start()
    {
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.GetReference("test");
        System.Threading.Tasks.Task<DataSnapshot> x = reference.GetValueAsync();
        DataSnapshot y = await x;
        Debug.Log(y.GetValue(false));

    }

    public void Authenticate()
    {
        Firebase.Auth.FirebaseAuth auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        auth.SignInWithEmailAndPasswordAsync("test@user.com", "test@user.comspa$$word1$eZ").ContinueWith(task => {
        if (task.IsCanceled) {
            Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
            return;
        }
        if (task.IsFaulted) {
            Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
            return;
        }

        Firebase.Auth.FirebaseUser newUser = task.Result;
        Debug.LogFormat("User signed in successfully: {0} ({1})",
            newUser.DisplayName, newUser.UserId);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
