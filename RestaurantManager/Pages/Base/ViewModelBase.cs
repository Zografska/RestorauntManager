using Prism.AppModel;
using Prism.Mvvm;
using Prism.Navigation;
using XCT.Popups.Prism;

namespace RestaurantManager
{
    public class ViewModelBase : BindableBase, INavigationAware, IDestructible, IPageLifecycleAware

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
    }
}