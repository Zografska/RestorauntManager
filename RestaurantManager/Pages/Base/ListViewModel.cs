using System.Collections.ObjectModel;
using System.Windows.Input;
using Prism.Navigation;
using RestaurantManager.Extensions;
using RestaurantManager.Model;
using RestaurantManager.Utility;
using XCT.Popups.Prism;

namespace RestaurantManager.Pages
{
    public class ListViewModel<T> : ViewModelBase
        where T : ModelBase
    {
        protected string PopupName { get; set; }
        public ICommand ItemTappedCommand { get; }
        public ICommand AddNoteCommand { get; }
        public ICommand AddShiftCommand { get; set; }
        
        private ObservableCollection<T> _items = new ObservableCollection<T>();
        public ObservableCollection<T> Items
        {
            get => _items;
            set => SetProperty(ref _items, value);
        }

        protected ListViewModel(INavigationService navigationService, IPopupService popupService) : base(
            navigationService, popupService)
        {
            ItemTappedCommand = new SingleClickCommand<object>(ShowPopup);
            AddNoteCommand = new SingleClickCommand(ShowCniPopup);
            AddShiftCommand = new SingleClickCommand(ShowCniPopup);
        }

        protected void HandlePopupResult(IPopupParameters resultParameters, T oldItem = null)
        {
            if (resultParameters.TryGetValue(Constants.NavigationConstants.ItemUpdated, out T item))
            {
                if (oldItem != null)
                {
                    int index = Items.IndexOf(oldItem);
                    Items.Remove(oldItem);
                    Items.Insert(index, item);
                }
                else
                {
                    Items.Add(item);
                }
            }
            else if (resultParameters.ContainsKey(Constants.NavigationConstants.ItemDeleted))
            {
                Items.Remove(oldItem);
            }
        }

        private async void ShowCniPopup()
        {
            IPopupResult result =
                await PopupService.ShowPopupAsync(PopupName, new PopupParameters { { Constants.NavigationConstants.Item, null } });

            HandlePopupResult(result.Parameters);
        }

        private async void ShowPopup(object tappedItem)
        {
            var item = tappedItem as T;

            IPopupResult result =
                await PopupService.ShowPopupAsync(PopupName, new PopupParameters { { Constants.NavigationConstants.Item, item.Clone() as T } });
            HandlePopupResult(result.Parameters, item);
        }
    }
}