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
    public class EditPopupViewModel<T> : BasePopupViewModel
        where T : ModelBase
    {
        private  IServiceBase<T> Service { get; set; }
        private T _item;

        public T Item
        {
            get => _item;
            set => SetProperty(ref _item, value);
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
        public ICommand DeleteCommand { get; }

        public EditPopupViewModel(INavigationService navigationService, IPopupService popupService,
            INetworkService networkService) : base(navigationService, popupService, networkService)
        {
            DeleteCommand = new Command(DeleteNote);
            SaveCommand = new Command(SaveItem);
        }

        public override void OnPopupOpened(IPopupParameters parameters)
        {
            base.OnPopupOpened(parameters);
            InitPopup(parameters);
        }

        protected virtual void InitPopup(IPopupParameters parameters)
        {
            T item;
            IServiceBase<T> service;
            parameters.TryGetValue(Constants.NavigationConstants.Item, out item);
            parameters.TryGetValue(Constants.NavigationConstants.Service, out service);
            
            if (item != null)
            {
                IsDeletePossible = true;
                IsEditing = true;
            }

            Service = service;
            Item = item ?? GenericHelpers.GetInstance<T>(typeof(T).FullName);
        }

        protected async virtual void SaveItem()
        {
            if (NetworkService.IsNetworkConnected())
            {
                var updatedNote = await Service.Save(Item);
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
            var answer =
                await Application.Current.MainPage.DisplayAlert("Delete Note", "Do you want to delete this note?",
                    "Yes", "No");

            if (!answer) return;

            if (NetworkService.IsNetworkConnected())
            {
                var itemDeleted = await Service.RemoveById(Item.Id);
                var parameters = new PopupParameters { { Constants.NavigationConstants.ItemDeleted, itemDeleted } };
                UpdateCommand.Execute(parameters);
            }
            else
            {
                DisplayAlert(Constants.AlertConstants.NoInternet);
            }
        }
    }
}