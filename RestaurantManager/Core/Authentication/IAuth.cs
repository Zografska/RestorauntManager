using System.Threading.Tasks;

namespace RestaurantManager.Core.Authentication
{
    public interface IAuthService
    {
        Task<string> LoginWithEmailPassword(string email, string password);
        Task<bool> SignUpWithEmailPassword(string email, string password);
        bool Logout();
        string GetCurrentProfile();
    }
}