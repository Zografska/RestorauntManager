using System;
using System.Threading.Tasks;
using Android.Gms.Extensions;
using Firebase.Auth;
using RestaurantManager.Core.Authentication;
using RestaurantManager.Droid.Core;
using Xamarin.Forms;

[assembly: Dependency(typeof(AuthDroid))]
namespace RestaurantManager.Droid.Core
{
    public class AuthDroid : IAuthService
    {
        public async Task<string> LoginWithEmailPassword(string email, string password)
        {
            try 
            {
                var user = await FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email, password);
                var token = await user.User.GetIdToken(false);
                return token.ToString();
            } 
            catch(FirebaseAuthInvalidUserException e)
            {
                e.PrintStackTrace();
                return "";
            }
        }

        public async Task<bool> SignUpWithEmailPassword(string email, string password)
        {
            try
            {
                var signUpTask = FirebaseAuth.Instance.CreateUserWithEmailAndPassword(email, password);

                return signUpTask.Result != null;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Logout()
        {
            try
            {
                FirebaseAuth.Instance.SignOut();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}