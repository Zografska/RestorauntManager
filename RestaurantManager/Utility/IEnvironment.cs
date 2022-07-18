using System.Drawing;

namespace RestaurantManager.Utility
{
    public interface IEnvironment
    {
        void SetStatusBarColor(Color color, bool darkStatusBarTint);
    }
}