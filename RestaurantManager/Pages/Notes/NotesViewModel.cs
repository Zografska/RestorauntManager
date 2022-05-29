using System.Collections.ObjectModel;
using Prism.Navigation;
using RestaurantManager.Model;
using RestaurantManager.Popups;
using RestaurantManager.Services;
using Rg.Plugins.Popup.Pages;
using XCT.Popups.Prism;

namespace RestaurantManager.Pages
{
    public class NotesViewModel : ListViewModel<Note>
    {
        private INoteService NoteService { get; set; }

        public NotesViewModel(INavigationService navigationService, IPopupService popupService, INoteService noteService) : base(navigationService, popupService)
        {
            Title = "Notes";
            NoteService = noteService;
            Items = new ObservableCollection<Note>(NoteService.GetAll());
            PopupName = nameof(NotePopup);
        }
    }
}