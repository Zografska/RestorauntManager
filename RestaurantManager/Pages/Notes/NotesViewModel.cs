using System;
using System.Windows.Input;
using Prism.Navigation;
using RestaurantManager.Core.DatabaseService;
using RestaurantManager.Model;
using RestaurantManager.Popups;
using RestaurantManager.Services;
using RestaurantManager.Services.Network;
using RestaurantManager.Utility;
using Xamarin.Forms;
using XCT.Popups.Prism;

namespace RestaurantManager.Pages.Notes
{
    public class NotesViewModel : ListViewModel<Note>
    {
        private readonly INoteService _noteService;
        private bool _isCreateButtonVisible;
        public bool IsCreateButtonVisible
        {
            get => _isCreateButtonVisible;
            set
            {
                _isCreateButtonVisible = value;
                RaisePropertyChanged(nameof(IsCreateButtonVisible));
            } 
        }
        public ICommand ChangeItemsCommand { get; set; }
        public NotesViewModel(INavigationService navigationService, IPopupService popupService, 
            DatabaseServiceRemote databaseServiceRemote, INoteService noteService, INetworkService networkService) 
            : base(navigationService, popupService, databaseServiceRemote, networkService)
        {
            Title = XamlConstants.MyNotes;
            _noteService = noteService;
            _service = noteService;
            PopupName = nameof(NotePopup);
            ChangeItemsCommand = new Command<string>(PopulateItems);

            NetworkService.OnNetworkStatusChanged.Subscribe(message => IsCreateButtonVisible = message.IsConnected);
        }

        public override async void Initialize(INavigationParameters parameters)
        {
            if (NetworkService.IsNetworkConnected())
            {
                IsCreateButtonVisible = true;
                Items = await _noteService.GetNotesByUser();
            }
            else
            {
                IsCreateButtonVisible = false;
                DisplayAlert(Constants.AlertConstants.NoInternet);
            }
        }

        private async void PopulateItems(string notesType)
        {
            Title = notesType;
            if (notesType.Equals(XamlConstants.MyNotes))
            {
                Items = await _noteService.GetNotesByUser();
                IsCreateButtonVisible = true;
            }
            else if(notesType.Equals(XamlConstants.SharedNotes))
            {
                Items = await _noteService.GetNotesSharedWithUser();
                IsCreateButtonVisible = false;
            }
        }
    }
}