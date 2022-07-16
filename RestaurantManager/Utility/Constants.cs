namespace RestaurantManager.Utility
{
    public class Constants
    {
        public class NavigationConstants
        {
            public const string ItemUpdated = "ItemUpdated";
            public const string ItemDeleted = "ItemDeleted";
            public const string ItemAdded = "ItemAdded";
            public const string Item = "Item";
        }

        public class AlertConstants
        {
            public const string LoginUnsuccessfulAlert = "Login unsuccessful. \n Please try again";
            public const string ValidationAlert = "Please fill in all the blanks";
            public static string LogoutUnsuccessful = "There was some trouble in logging you out \n Please try again";
        }
    }
}