using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using RestaurantManager.Core.Authentication;
using RestaurantManager.Core.DatabaseService;
using RestaurantManager.Extensions;
using RestaurantManager.Model;
using RestaurantManager.Services.Network;
using RestaurantManager.Utility;


namespace RestaurantManager.Services
{
    public class NoteService : BaseCrudService<Note>, INoteService
    {
        public NoteService(DatabaseServiceRemote databaseServiceRemote, IAuthService authService,
            INetworkService networkService) : base(databaseServiceRemote, authService, networkService)
        { }

        public override Task<Note> Save(Note note)
        {
            note.CreatorUid = AuthService.GetCurrentProfile();
            return base.Save(note);
        }

        public override async Task<bool> Update(Note note)
        {
            if (note == null)
            {
                return false;
            }
            note.LastModified = DateTime.Now;
            return await base.Update(note);
        }

        public async Task<ObservableCollection<Note>> GetNotesByUser()
        { 
            if (NetworkService.IsNetworkConnected())
            {
                var currentUser = AuthService.GetCurrentProfile();
                var allNotes = await GetAll();
                return allNotes.Where(note => note.CreatorUid == currentUser).ToObservableCollection();
            }
           
            return new ObservableCollection<Note>();
        }

        public async Task<ObservableCollection<Note>> GetNotesSharedWithUser()
        {
            //TODO: Implement dropdown for picking employees
            return await GetAll();
        }
    }
}