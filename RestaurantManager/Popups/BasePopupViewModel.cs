using System;
using Prism.Commands;
using Prism.Navigation;
using XCT.Popups.Prism;

namespace RestaurantManager.PopUps
{
    public class BasePopupViewModel : ViewModelBase, IPopupAware, IPopupLightDismissAware
    {
        public DelegateCommand DismissCommand { get; }
        public DelegateCommand<IPopupParameters> UpdateCommand { get; }

        public event Action<IPopupParameters> RequestDismiss;

        public BasePopupViewModel(INavigationService navigationService, IPopupService popupService)
            : base(navigationService, popupService)
        {
            DismissCommand = new DelegateCommand(DimsissCommandExecuted);
            UpdateCommand = new DelegateCommand<IPopupParameters>(UpdateCommandExecuted);
        }

        public virtual void OnPopupOpened(IPopupParameters parameters)
        { }

        public void OnPopupDismissed()
        { }
        
        private void UpdateCommandExecuted(IPopupParameters parameters)
        {
            RequestDismiss?.Invoke(parameters);
        }

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
