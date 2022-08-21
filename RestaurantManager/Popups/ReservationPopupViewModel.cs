using System.Windows.Input;
using Prism.Navigation;
using RestaurantManager.Model;
using RestaurantManager.Services.Network;
using Xamarin.Forms;
using XCT.Popups.Prism;

namespace RestaurantManager.Popups
{
    public class ReservationPopupViewModel : EditPopupViewModel<Reservation>
    {
        public ICommand PartyPickedCommand { get; set; }

        public ReservationPopupViewModel(INavigationService navigationService, IPopupService popupService,
            INetworkService networkService) : base(navigationService,
            popupService, networkService)
        {
            PartyPickedCommand = new Command<int>(PartyPicked);
        }

        private void PartyPicked(int numberOfPeople)
        {
            Item.NumberOfPeople = numberOfPeople;
        }
    }
}