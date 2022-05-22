using System.Collections.ObjectModel;
using System.Windows.Input;
using Prism.Navigation;
using RestaurantManager.Model;
using RestaurantManager.Pages.Base;
using RestaurantManager.Services;
using RestaurantManager.Utility;
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
        
        public ICommand ItemTappedCommand { get; }
        public ICommand AddNoteCommand { get; }
        
        public NotesViewModel(INavigationService navigationService, IPopupService popupService, INoteService noteService) : base(navigationService, popupService)
        {
            Title = "Notes";
            NoteService = noteService;
            Notes = NoteService.GetAll();
            ItemTappedCommand = new SingleClickCommand<object>(ShowNotePopup);
            AddNoteCommand = new SingleClickCommand(ShowCniPopup);
        }

        private async void ShowCniPopup()
        {
            IPopupResult result = await PopupService.ShowPopupAsync("NotePopup", new PopupParameters {{"Item", null}});
            
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