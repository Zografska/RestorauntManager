using Prism.Mvvm;
using Prism.Navigation;
using XCT.Popups.Prism;

namespace RestaurantManager
{
    public class ViewModelBase : BindableBase, INavigationAware, IDestructible

    {
        protected INavigationService NavigationService { get; }
        protected IPopupService PopupService { get; }

        private string _title;

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public ViewModelBase(INavigationService navigationService, IPopupService popupService)
        {
            NavigationService = navigationService;
            PopupService = popupService;
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
        }

        public void Destroy()
        {
        }
    }
}