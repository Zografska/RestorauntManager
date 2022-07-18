using RestaurantManager.Core.DatabaseService;
using RestaurantManager.Model;

namespace RestaurantManager.Services
{
    public class ItemsService : BaseCrudService<Item>, IItemsService
    {
        protected ItemsService(DatabaseServiceRemote databaseServiceRemote) : base(databaseServiceRemote)
        {
        }
    }
}