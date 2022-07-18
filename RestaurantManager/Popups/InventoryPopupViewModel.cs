using System.Windows.Input;
using Prism.Navigation;
using RestaurantManager.Model;
using RestaurantManager.PopUps;
using RestaurantManager.Services;
using RestaurantManager.Utility;
using Xamarin.Forms;
using XCT.Popups.Prism;

namespace RestaurantManager.Popups
{
    public class InventoryPopupViewModel : BasePopupViewModel
    {
        public IItemsService ItemsService { get; set; }
        private Item _item;

        public Item Item
        {
            get => _item;
            set => SetProperty(ref _item, value);
        }
        
        private bool _isDeletePossible;
        public bool IsDeletePossible
        {
            get => _isDeletePossible;
            set => SetProperty(ref _isDeletePossible, value);
        }

        public ICommand SaveCommand { get; }
        public Command DeleteCommand { get; }

        public InventoryPopupViewModel(INavigationService navigationService, IPopupService popupService,
            IItemsService itemsService) : base(navigationService, popupService)
        {
            ItemsService = itemsService;
            SaveCommand = new Command(SaveItem);
            DeleteCommand = new Command(DeleteItem);
        }

        public override void OnPopupOpened(IPopupParameters parameters)
        {
            base.OnPopupOpened(parameters);
            InitPopup(parameters);
        }

        private void InitPopup(IPopupParameters parameters)
        {
            Item item;
            parameters.TryGetValue("Item", out item);

            if (item != null)
            {
                IsDeletePossible = true;
            }

            Item = item ?? new Item();
        }
        private async void SaveItem()
        {
            var updatedItem = await ItemsService.Save(Item);
            var parameters = new PopupParameters { { Constants.NavigationConstants.ItemUpdated, updatedItem } };
            UpdateCommand.Execute(parameters);
        }
        
        private async void DeleteItem()
        {
            var answer = await Application.Current.MainPage.DisplayAlert("Delete Item", "Do you want to delete this Item?", "Yes", "No");
            if (answer)
            {
                var itemDeleted = await ItemsService.RemoveById(Item.Id);
                var parameters = new PopupParameters() { {  Constants.NavigationConstants.ItemDeleted, itemDeleted } };
                UpdateCommand.Execute(parameters);
            }
        }
        
    }
}