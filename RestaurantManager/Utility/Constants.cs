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
            public static string Service = "Service";
            public static string Date = "Date";
            public const string Employee = "Employee";
        }

        public class AlertConstants
        {
            public const string LoginUnsuccessfulAlert = "Login unsuccessful. \n Please try again";
            public const string ResetInstructionsSent = "Reset instructions sent to your email";
            public const string LogoutUnsuccessful = "There was some trouble in logging you out \n Please try again";
            public const string NoInternet = "Please connect to the internet :( <3";
            public const string BackOnline = "You're back online :)";
        }

        public class FeatureConstants
        {
            public const string FeatureNotImplemented = "Feature not implemented";
            public const string PermissionsNotGranted = "Permissions not granted";
        }
    }
}