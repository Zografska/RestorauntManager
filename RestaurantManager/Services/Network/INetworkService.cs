using System;

namespace RestaurantManager.Services.Network
{
    public interface INetworkService
    {
        bool IsNetworkConnected();
        IObservable<NetworkStatusMessage> OnNetworkStatusChanged { get; }
    }
}