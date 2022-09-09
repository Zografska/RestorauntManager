using System.Linq;
using System.Threading.Tasks;
using RestaurantManager.Core.Authentication;
using RestaurantManager.Core.DatabaseService;
using RestaurantManager.Model;
using RestaurantManager.Services.Network;

namespace RestaurantManager.Services
{
    public class ProfileService : BaseCrudService<User>, IProfileService
    {
        public ProfileService(DatabaseServiceRemote databaseServiceRemote, IAuthService authService,
            INetworkService networkService) : base(databaseServiceRemote, authService, networkService)
        { }

        public async Task<User> GetCurrentUser()
        {
            var currentUserId = AuthService.GetCurrentProfile();
            return (await GetAll()).FirstOrDefault(user => user.Uid == currentUserId);
        }

        public async Task<User> CreateUser(string userId,string name, string surname, string email)
        {
            var newUser = new User
            {
                Uid = userId,
                Name = name,
                Surname = surname,
                Email = email,
                FullName = $"{name} {surname}"
            };

           return await Save(newUser);
        }

        public async Task<bool> IsUserExistent(string email)
        {
            var users = await GetAll();
            return users.FirstOrDefault(user => user.Email == email) != default;
        }

        // TODO: find a smarter way to create a password for the google user
        public string GetGoogleUserPassword(string googleUserEmail)
        {
            return googleUserEmail.GetHashCode().ToString();
        }
    }
}