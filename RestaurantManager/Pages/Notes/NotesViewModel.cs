using Prism.Navigation;
using RestaurantManager.Core.DatabaseService;
using RestaurantManager.Model;
using RestaurantManager.Popups;
using XCT.Popups.Prism;

namespace RestaurantManager.Pages
{
    public class NotesViewModel : ListViewModel<Note>
    {
        public NotesViewModel(INavigationService navigationService, IPopupService popupService, 
            DatabaseServiceRemote databaseServiceRemote) : base(navigationService, popupService, databaseServiceRemote)
        {
            Title = "Notes";
            PopupName = nameof(NotePopup);
        }
    }
}