using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Prism.Navigation;
using RestaurantManager.Core.DatabaseService;
using RestaurantManager.Extensions;
using RestaurantManager.Model;
using RestaurantManager.Services;
using RestaurantManager.Services.Network;
using RestaurantManager.Utility;
using Xamarin.Forms.Internals;
using XCT.Popups.Prism;

namespace RestaurantManager.Pages
{
    public class ListViewModel<T> : ViewModelBase
        where T : ModelBase
    {
        protected readonly DatabaseServiceRemote _databaseServiceRemote;
        protected IServiceBase<T> _service { get; set; }
        protected string PopupName { get; set; }
        public ICommand ItemTappedCommand { get; }
        public ICommand AddItemCommand { get; }
        
        private ObservableCollection<T> _items = new ObservableCollection<T>();
        public ObservableCollection<T> Items
        {
            get => _items;
            set => SetProperty(ref _items, value);
        }
        
        protected ListViewModel(INavigationService navigationService, IPopupService popupService,
            DatabaseServiceRemote databaseServiceRemote, INetworkService networkService) 
            : base(navigationService, popupService, networkService)
        {
            _databaseServiceRemote = databaseServiceRemote;
            
            ItemTappedCommand = new SingleClickCommand<object>(ShowPopup);
            AddItemCommand = new SingleClickCommand<IEnumerable<KeyValuePair<string, object>>>(ShowCniPopup);
        }

        protected virtual T HandlePopupResult(IPopupParameters resultParameters, T oldItem = null)
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
                    Items = new ObservableCollection<T>(Items);
                }
            }
            else if (resultParameters.ContainsKey(Constants.NavigationConstants.ItemDeleted))
            {
                Items.Remove(oldItem);
                Items = new ObservableCollection<T>(Items);
            }

            return item;
        }

        protected virtual async void ShowCniPopup(IEnumerable<KeyValuePair<string, object>> additionalKeys = null)
        {
            var popupParameters = new PopupParameters
            {
                { Constants.NavigationConstants.Item, null }, 
                { Constants.NavigationConstants.Service, _service }
            };

            additionalKeys?.ForEach(pair => popupParameters.Add(pair.Key, pair.Value));

            IPopupResult result =
                await PopupService.ShowPopupAsync(PopupName, popupParameters);
            
            HandlePopupResult(result.Parameters);
        }

        private async void ShowPopup(object tappedItem)
        {
            var item = tappedItem as T;

            IPopupResult result =
                await PopupService.ShowPopupAsync(PopupName, new PopupParameters
                {
                    { Constants.NavigationConstants.Item, item.Clone() as T },
                    { Constants.NavigationConstants.Service, _service }
                });
            HandlePopupResult(result.Parameters, item);
        }
    }
}