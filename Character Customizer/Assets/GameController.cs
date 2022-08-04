using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FirebaseWebGL.Scripts.FirebaseBridge;
public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    async void Start()
    {
        // DatabaseReference reference = FirebaseDatabase.DefaultInstance.GetReference("test");
        // System.Threading.Tasks.Task<DataSnapshot> x = reference.GetValueAsync();
        // DataSnapshot y = await x;
        // Debug.Log(y.GetValue(false));

    }

    public void Authenticate()
    {
        FirebaseAuth.SignInWithGoogle(gameObject.name, "DisplayInfo", "DisplayErrorObject");
    }

    public void DisplayInfo(string info)
    {
        Debug.Log(info);
    }

    public void DisplayErrorObject(string error)
    {
        Debug.Log(error);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
