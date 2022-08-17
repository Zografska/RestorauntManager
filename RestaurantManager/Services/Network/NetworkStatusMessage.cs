using System.Diagnostics.CodeAnalysis;

namespace RestaurantManager.Services
{
    [ExcludeFromCodeCoverage]
    public class NetworkStatusMessage
    {
        public bool IsConnected { get; set; }

        public NetworkStatusMessage(bool isConnected)
        {
            IsConnected = isConnected;
        }
    }
}