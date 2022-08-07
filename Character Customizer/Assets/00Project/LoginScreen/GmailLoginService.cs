
using FirebaseWebGL.Examples.Utils;
using FirebaseWebGL.Scripts.FirebaseBridge;
using FirebaseWebGL.Scripts.Objects;

namespace CaptainCoder
{

    public class GmailLoginService : LoginService
    {
        public GmailLoginService(LoginController controller) : base(controller) {
            FirebaseAuth.OnAuthStateChanged(controller.name, "OnSignedIn", "OnSignedOut");
        }

        public override void Authenticate()
        {
            FirebaseAuth.SignInWithGoogle(controller.name, "DisplayInfo", "DisplayErrorObject");
        }

        public override void Logout()
        {
            FirebaseAuth.Signout(controller.name, "Debug", "Debug");
        }

        public override void OnSignedIn(string data)
        {
            var parsedUser = StringSerializationAPI.Deserialize(typeof(FirebaseUser), data) as FirebaseUser;
            controller.Debug($"Signed In: {parsedUser.uid}, {parsedUser.displayName}, {parsedUser.email}");
        }

        public override void OnSignedOut(string data)
        {
            controller.Debug($"Signed Out: {data}");
        }
    }
}