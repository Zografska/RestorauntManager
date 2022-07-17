using RestaurantManager.Core.DatabaseService;
using RestaurantManager.Model;

namespace RestaurantManager.Services
{
    public class EmployeeService : BaseCrudService<Employee>, IEmployeeService
    {
        public EmployeeService(DatabaseServiceRemote databaseServiceRemote) : base(databaseServiceRemote)
        {
        }
    }
}