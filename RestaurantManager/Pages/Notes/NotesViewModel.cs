using Prism.Navigation;
using RestaurantManager.Core.DatabaseService;
using RestaurantManager.Model;
using RestaurantManager.Popups;
using RestaurantManager.Services;
using XCT.Popups.Prism;

namespace RestaurantManager.Pages.Notes
{
    public class NotesViewModel : ListViewModel<Note>
    {
        private readonly INoteService _noteService;
        public NotesViewModel(INavigationService navigationService, IPopupService popupService, 
            DatabaseServiceRemote databaseServiceRemote, INoteService noteService) : base(navigationService, popupService, databaseServiceRemote)
        {
            Title = "Notes";
            _noteService = noteService;
            PopupName = nameof(NotePopup);
        }

        public async void PopulateItems(string notesType)
        {
            // TODO: remove this hack...
            // Figure out why IObservableCollection<Note> bindable property
            // was not responding to changes of collection from the NotesTabbedPage
            
            if (notesType.Equals("MyNotes"))
            {
                Items = await _noteService.GetNotesByUser();
            }
            else if(notesType.Equals("MyNotes"))
            {
                Items = await _noteService.GetNotesSharedWithUser();
            }
        }
    }
}