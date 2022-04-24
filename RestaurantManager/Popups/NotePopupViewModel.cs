using System;
using System.Windows.Input;
using Prism.Navigation;
using RestaurantManager.Model;
using RestaurantManager.PopUps;
using RestaurantManager.Services;
using Xamarin.Forms;
using XCT.Popups.Prism;

namespace RestaurantManager.Popups
{
    public class NotePopupViewModel : BasePopupViewModel
    {
        public INoteService NoteService { get; set; }
        private Note _note;
        public Note Note
        {
            get => _note;
            set => SetProperty(ref _note, value);
        }

        public ICommand SaveCommand { get; }
        
        public NotePopupViewModel(INavigationService navigationService, IPopupService popupService, INoteService noteService) : base(navigationService, popupService)
        {
            NoteService = noteService;
            SaveCommand = new Command(SaveNote);
        }
        
        public override void OnPopupOpened(IPopupParameters parameters)
        { 
            base.OnPopupOpened(parameters);
            InitPopup(parameters);
        }
        
        private void InitPopup(IPopupParameters parameters)
        {
            Note note;
            parameters.TryGetValue("Item", out note);
            Note = note;
        }
        
        private void SaveNote()
        {
            NoteService.UpdateNote(Note);
            var parameters = new PopupParameters() { { "Item", Note } };
            UpdateCommand.Execute(parameters);
        }
    }
    
}