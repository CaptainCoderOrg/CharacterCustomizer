#if UNITY_EDITOR
using System;
using UnityEngine;
namespace CaptainCoder
{

    public class EmailLoginService : LoginService
    {
        private Action _logout;
        public EmailLoginService(LoginController controller) : base(controller) {
            Firebase.Auth.FirebaseAuth auth = Firebase.Auth.FirebaseAuth.DefaultInstance;            
            auth.StateChanged += HandleStateChanged;
        }
        public override void Authenticate()
        {
            Firebase.Auth.FirebaseAuth auth = Firebase.Auth.FirebaseAuth.DefaultInstance;                        
            auth.SignInWithEmailAndPasswordAsync("dev@user.com", "Agh8tbs23").ContinueWith(task =>
            {
                if (task.IsCanceled)
                {
                    Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
                    controller.DisplayErrorObject("Email LoginService: SignInWithEmailAndPasswordAsync was canceled.");
                    return;
                }
                if (task.IsFaulted)
                {
                    Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                    controller.DisplayErrorObject("Email LoginService: SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                    return;
                }

                Firebase.Auth.FirebaseUser newUser = task.Result;
                controller.DisplayInfo($"User signed in successfully: {newUser.DisplayName}, {newUser.UserId}");
            });
        }

        public override void Logout()
        {
            if (_logout == null) return;
            this._logout.Invoke();
            this._logout = null;
        }

        private void HandleStateChanged(object sender, EventArgs e)
        {
            if(typeof(Firebase.Auth.FirebaseAuth) != sender.GetType()) return;
            Firebase.Auth.FirebaseAuth auth = (Firebase.Auth.FirebaseAuth)sender;   
            this._logout = () => auth.SignOut();
            string displayName = auth.CurrentUser == null ? "Not Logged In" : auth.CurrentUser.Email;
            controller.Debug($"CurrentUser: {displayName}");
        }

    }
}
#endif