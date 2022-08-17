using System.Windows.Input;
using Prism.Navigation;
using RestaurantManager.Model;
using RestaurantManager.PopUps;
using RestaurantManager.Services;
using RestaurantManager.Services.Network;
using RestaurantManager.Utility;
using Xamarin.Forms;
using XCT.Popups.Prism;

namespace RestaurantManager.Popups
{
    public class NotePopupViewModel : BasePopupViewModel
    {
        private INoteService NoteService { get; set; }
        private Note _note;
        public Note Note
        {
            get => _note;
            set => SetProperty(ref _note, value);
        }
        
        private bool _isEditing;
        public bool IsEditing
        {
            get => _isEditing;
            set => _isEditing = value;
        }

        private bool _isDeletePossible;

        public bool IsDeletePossible
        {
            get => _isDeletePossible;
            set => SetProperty(ref _isDeletePossible, value);
        }

        public ICommand SaveCommand { get; }
        public Command DeleteCommand { get; }

        public NotePopupViewModel(INavigationService navigationService, IPopupService popupService,
            INoteService noteService, INetworkService networkService) 
            : base(navigationService, popupService, networkService)
        {
            NoteService = noteService;
            DeleteCommand = new Command(DeleteNote);
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
            parameters.TryGetValue(Constants.NavigationConstants.Item, out note);

            if (note != null)
            {
                IsDeletePossible = true;
                IsEditing = true;
            }

            Note = note ?? new Note();
        }
        
        private async void SaveNote()
        {
            if (NetworkService.IsNetworkConnected())
            {
                var updatedNote = await NoteService.Save(Note);
                var parameters = new PopupParameters { { Constants.NavigationConstants.ItemUpdated, updatedNote } };
                UpdateCommand.Execute(parameters);
            }
            else
            {
                DisplayAlert(Constants.AlertConstants.NoInternet);
            }
        }
        
        private async void DeleteNote()
        {
           var answer = await Application.Current.MainPage.DisplayAlert("Delete Note", "Do you want to delete this note?", "Yes", "No");
           
           if(!answer) return;
          
           if (NetworkService.IsNetworkConnected())
           {
               var itemDeleted = await NoteService.RemoveById(Note.Id);
               var parameters = new PopupParameters { {  Constants.NavigationConstants.ItemDeleted, itemDeleted } };
               UpdateCommand.Execute(parameters);
           }
           else
           {
               DisplayAlert(Constants.AlertConstants.NoInternet);
           }
        }
    }
    
}