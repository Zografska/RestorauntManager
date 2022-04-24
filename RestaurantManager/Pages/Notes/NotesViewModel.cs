using System.Collections.ObjectModel;
using Prism.Navigation;
using RestaurantManager.Model;
using RestaurantManager.Pages.Base;
using RestaurantManager.Services;
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
        
        public Command<object> ItemTappedCommand { get; set; }
        
        public NotesViewModel(INavigationService navigationService, IPopupService popupService, INoteService noteService) : base(navigationService, popupService)
        {
            Title = "Notes";
            NoteService = noteService;
            Notes = NoteService.GetAllNotes();
            ItemTappedCommand = new Command<object>(ShowNotePopup);
        }
        
        private async void ShowNotePopup(object tappedNote)
        {
            var note = tappedNote as Note;
            
            IPopupResult result = await PopupService.ShowPopupAsync("NotePopup", new PopupParameters {{"Item", note}});
            UpdateNote(note, result.Parameters);
        }

        private void UpdateNote(Note oldNote, IPopupParameters resultParameters)
        {
            Note updatedNote;
            if (resultParameters.TryGetValue("Item", out updatedNote))
            {
                int index = Notes.IndexOf(oldNote);
                Notes.Remove(oldNote);
                Notes.Insert(index, updatedNote);
            }
        }
    }
}