using Prism.Navigation;
using RestaurantManager.Model;
using RestaurantManager.Services.Network;
using XCT.Popups.Prism;

namespace RestaurantManager.Popups
{
    public class NotePopupViewModel : EditPopupViewModel<Note>
    {
        public NotePopupViewModel(INavigationService navigationService, IPopupService popupService,
            INetworkService networkService) : base(navigationService, popupService, networkService)
        {
        }
    }
}