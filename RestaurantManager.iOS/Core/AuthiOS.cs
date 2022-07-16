using System;
using System.Threading.Tasks;
using Firebase.Auth;
using Foundation;
using RestaurantManager.Core.Authentication;
using RestaurantManager.iOS.Core;
using Xamarin.Forms;

[assembly: Dependency(typeof(AuthiOS))]

namespace RestaurantManager.iOS.Core
{
    public class AuthiOS : IAuthService
    {

        public async Task<string> LoginWithEmailPassword(string email, string password)
        {
            try
            {
                var user = await Auth.DefaultInstance.SignInWithPasswordAsync(email, password);
                return await user.User.GetIdTokenAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "";
            }

        }

        public async Task<bool> SignUpWithEmailPassword(string email, string password)
        {
            try
            {
                var signUpTask = Auth.DefaultInstance.CreateUserAsync(email, password);
                var res = await signUpTask;
                return signUpTask.Result != null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool Logout()
        {
            try
            {
                _ = Auth.DefaultInstance.SignOut(out NSError error);
                return error == null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
        public string GetCurrentProfile()
        {
            return Auth.DefaultInstance.CurrentUser.Uid;
        }
    }
}