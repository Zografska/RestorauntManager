using System;
using Prism.Commands;
using Prism.Navigation;
using XCT.Popups.Prism;

namespace RestaurantManager.PopUps
{
    public class BasePopupViewModel : ViewModelBase, IPopupAware, IPopupLightDismissAware
    {
        public DelegateCommand DismissCommand { get; }

        public event Action<IPopupParameters> RequestDismiss;

        public BasePopupViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            DismissCommand = new DelegateCommand(DimsissCommandExecuted);
        }

        public virtual void OnPopupOpened(IPopupParameters parameters)
        { }

        public void OnPopupDismissed()
        { }

        private void DimsissCommandExecuted()
        {
            RequestDismiss?.Invoke(new PopupParameters()
            {
                { "dismissedParam", "This was returned from the popup viewmodel" }
            });
        }

        public IPopupParameters OnPopupLightDismissed()
        {
            return new PopupParameters()
            {
                { "lightDismissedParam", "This was returned from the popup viewmodel when it was light dismissed" }
            };
        } 
    }
}
