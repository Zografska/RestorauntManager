using System;
using System.Threading.Tasks;
using RestaurantManager.Model;


namespace RestaurantManager.Services
{
    public class NoteService : BaseCrudService<Note>, INoteService
    {
        public NoteService(DatabaseServiceRemote databaseServiceRemote): base(databaseServiceRemote)
        { }

        public override async Task<bool> Update(Note note)
        {
            if (note == null)
            {
                return false;
            }
            note.LastModified = DateTime.Now;
            return await base.Update(note);
        }

    }
}