using UnityEngine;
namespace CaptainCoder
{
    public abstract class LoginService
    {
        protected readonly LoginController controller;
        public static LoginService GetService(LoginController controller)
        {
            return Application.platform switch {
                RuntimePlatform.WebGLPlayer => new GmailLoginService(controller),
                _ => new EmailLoginService(controller)
            };
        }

        protected LoginService(LoginController controller)
        {
            this.controller = controller;
        }

        public abstract void Authenticate();
        public abstract void Logout();

        public virtual void OnSignedIn(string data)
        {
            this.controller.Debug(data);
        }
        public virtual void OnSignedOut(string data)
        {
            this.controller.Debug(data);
        }

    }
}