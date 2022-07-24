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
                return user.User.Uid;
            } 
            catch(FirebaseAuthInvalidUserException e)
            {
                e.PrintStackTrace();
                return "";
            }
        }

        public async Task<string> SignUpWithEmailPassword(string email, string password)
        {
            try
            {
                IAuthResult authResult = await FirebaseAuth.Instance.CreateUserWithEmailAndPasswordAsync(email, password);
                return authResult.User.Uid;
            }
            catch (Exception e)
            {
                return string.Empty;
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

        public string GetCurrentProfile()
        {
            return FirebaseAuth.Instance.CurrentUser.Uid;
        }

        public async Task ResetPassword(string email)
        {
            await FirebaseAuth.Instance.SendPasswordResetEmailAsync(email);
        }
    }
}