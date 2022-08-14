using System;
using System.Windows.Input;
using Prism.AppModel;
using Prism.Mvvm;
using Prism.Navigation;
using RestaurantManager.Services.Network;
using RestaurantManager.Utility;
using Xamarin.Forms;
using XCT.Popups.Prism;

namespace RestaurantManager
{
    public class ViewModelBase : BindableBase, INavigationAware, IDestructible, IPageLifecycleAware

    {
        private bool _isBackButtonVisible;

        public bool IsBackButtonVisible
        {
            get => _isBackButtonVisible;
            set
            {
                _isBackButtonVisible = value;
                RaisePropertyChanged(nameof(IsBackButtonVisible));   
            }
        }
        
        private bool _isLogoutButtonVisible;

        public bool IsLogoutButtonVisible
        {
            get => _isLogoutButtonVisible;
            set
            {
                _isLogoutButtonVisible = value;
                RaisePropertyChanged(nameof(IsLogoutButtonVisible));   
            }
        } 
        
        private bool _isNetworkConnected;

        public bool IsNetworkConnected
        {
            get => _isNetworkConnected;
            set
            {
                _isNetworkConnected = value;
                RaisePropertyChanged(nameof(IsNetworkConnected));   
            }
        }
        protected INavigationService NavigationService { get; }
        protected IPopupService PopupService { get; }
        protected INetworkService NetworkService { get; }

        private string _title;

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public ICommand NavigateBackCommand { get; }
        public ViewModelBase(INavigationService navigationService, IPopupService popupService, INetworkService networkService)
        {
            NavigationService = navigationService;
            PopupService = popupService;
            NetworkService = networkService;
            NavigateBackCommand = new SingleClickCommand(NavigateBack);
            IsBackButtonVisible = true;
            IsLogoutButtonVisible = true;
            NetworkService.OnNetworkStatusChanged.Subscribe(message =>
            {
                IsNetworkConnected = message.IsConnected;
            });
        }

        private void NavigateBack()
        {
            NavigationService.GoBackAsync();
        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
        }

        public virtual void Destroy()
        {
        }

        public virtual void OnAppearing()
        {
            IsNetworkConnected = NetworkService.IsNetworkConnected();
        }

        public virtual void OnDisappearing()
        {
        }

        protected virtual async void DisplayAlert(string alertMessage, string title = "")
        {
            await Application.Current.MainPage.DisplayAlert(title, alertMessage, "OK");
        }
    }
}