using Prism.Mvvm;
using Prism.Navigation;

namespace RestaurantManager
{
    public class ViewModelBase : BindableBase, INavigationAware, IDestructible

    {
        protected INavigationService NavigationService { get; private set; }

        private string _title;

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public ViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;
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