using System.Collections.Generic;
using System.Threading.Tasks;
using RestaurantManager.Model;

namespace RestaurantManager.Services
{
    public interface IProfileService : IServiceBase<User>
    {
        Task<User> GetCurrentUser();
        Task<User> CreateUser(string userId, string name, string surname, string email);
        Task<bool> IsUserExistent(string email);
        string GetGoogleUserPassword(string googleUserEmail);
    }
}