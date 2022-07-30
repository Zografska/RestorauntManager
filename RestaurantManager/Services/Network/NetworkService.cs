using System;
using System.Reactive.Subjects;
using Xamarin.Essentials;
namespace RestaurantManager.Services.Network
{
    public class NetworkService : INetworkService
    {
        private Subject<NetworkStatusMessage> _onNetworkStatusChanged;
        public IObservable<NetworkStatusMessage> OnNetworkStatusChanged => _onNetworkStatusChanged;
        public NetworkService()
        {
            _onNetworkStatusChanged = new Subject<NetworkStatusMessage>();
            Connectivity.ConnectivityChanged += ConnectivityOnConnectivityChanged;
        }

        private void ConnectivityOnConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            _onNetworkStatusChanged.OnNext(new NetworkStatusMessage(e.NetworkAccess == NetworkAccess.Internet));
        }

        public bool IsNetworkConnected()
        {
            return Connectivity.NetworkAccess == NetworkAccess.Internet;
        }
    }
}