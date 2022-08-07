#if !UNITY_EDITOR
using System;
using UnityEngine;
namespace CaptainCoder
{

    public class EmailLoginService : LoginService
    {

        public EmailLoginService(LoginController controller) : base(controller) {}
        public override void Authenticate() {
            controller.DisplayErrorObject("Cannot use EmailLoginService in WEBGL Build.");
        }
        public override void Logout()
        {
            controller.DisplayErrorObject("Cannot use EmailLoginService in WEBGL Build.");
        }
    }
}
#endif