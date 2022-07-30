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