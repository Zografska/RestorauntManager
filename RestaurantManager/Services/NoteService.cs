using System;
using System.Threading.Tasks;
using RestaurantManager.Model;


namespace RestaurantManager.Services
{
    public class NoteService : BaseCrudService, INoteService
    {
        public NoteService(DatabaseServiceRemote databaseServiceRemote): base(databaseServiceRemote)
        {

        }

        public override async Task<bool> Update<T>(T updatedEntity)
        {
            var shift = updatedEntity as Note;
            if (shift == null)
            {
                return false;
            }
            shift.LastModified = DateTime.Now;
            return await base.Update(shift);
        }
    }
}