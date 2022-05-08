using System.Collections.ObjectModel;
using Prism.Navigation;
using RestaurantManager.Model;
using RestaurantManager.Pages.Base;
using RestaurantManager.Services;
using RestaurantManager.Utility;
using Xamarin.Forms;
using XCT.Popups.Prism;

namespace RestaurantManager.Pages
{
    public class NotesViewModel : PageViewModelBase
    {
        private INoteService NoteService { get; set; }
        private ObservableCollection<Note> _notes = new ObservableCollection<Note>();
        public ObservableCollection<Note> Notes
        {
            get => _notes;
            set => SetProperty(ref _notes, value);
        }
        
        public Command<object> ItemTappedCommand { get; }
        public Command AddNoteCommand { get; }
        
        public NotesViewModel(INavigationService navigationService, IPopupService popupService, INoteService noteService) : base(navigationService, popupService)
        {
            Title = "Notes";
            NoteService = noteService;
            Notes = NoteService.GetAllNotes();
            ItemTappedCommand = new Command<object>(ShowNotePopup);
            AddNoteCommand = new Command(ShowCniPopup);
        }

        private async void ShowCniPopup()
        {
            IPopupResult result = await PopupService.ShowPopupAsync("NotePopup", new PopupParameters {{"Item", new Note()}});
            
            Note note;
            HandlePopupResult(result.Parameters);
        }

        private async void ShowNotePopup(object tappedNote)
        {
            var note = tappedNote as Note;
            
            IPopupResult result = await PopupService.ShowPopupAsync("NotePopup", new PopupParameters {{"Item", note}});
            HandlePopupResult(result.Parameters, note);
        }

        private void HandlePopupResult(IPopupParameters resultParameters, Note oldNote = null)
        {
            Note note;
            if (resultParameters.TryGetValue(Constants.NavigationConstants.ItemUpdated, out note))
            {
                if (oldNote != null)
                {
                    int index = Notes.IndexOf(oldNote);
                    Notes.Remove(oldNote);
                    Notes.Insert(index, note);
                }
                else
                {
                    Notes.Add(note);
                }
            }
            else if (resultParameters.ContainsKey(Constants.NavigationConstants.ItemDeleted))
            {
                Notes.Remove(oldNote);
            }
        }
    }
}