using Plugin.FirebasePushNotification;
using Prism;
using Prism.DryIoc;
using Prism.Ioc;
using RestaurantManager.Core.DatabaseService;
using RestaurantManager.Extensions;
using RestaurantManager.Pages;
using RestaurantManager.Pages.Authentication.Login;
using RestaurantManager.Pages.Authentication.ResetPassword;
using RestaurantManager.Pages.Authentication.Signup;
using RestaurantManager.Pages.Employees;
using RestaurantManager.Pages.Notes;
using RestaurantManager.Pages.Reservations;
using RestaurantManager.Pages.Settings;
using RestaurantManager.Pages.Welcome;
using RestaurantManager.Popups;
using RestaurantManager.Services;
using RestaurantManager.Services.Network;
using RestaurantManager.Utility;
using Xamarin.Forms;
using XCT.Popups.Prism;

namespace RestaurantManager
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer) : base(initializer) {}

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IProfileService, ProfileService>();
            containerRegistry.RegisterSingleton<IPopupService, PopupService>();
            containerRegistry.RegisterSingleton<INoteService, NoteService>();
            containerRegistry.RegisterSingleton<IShiftsService, ShiftsService>();
            containerRegistry.RegisterSingleton<INetworkService, NetworkService>();
            containerRegistry.RegisterSingleton<IReservationService, ReservationService>();
            
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<SignupPage, SignupPageViewModel>();
            containerRegistry.RegisterForNavigation<ResetPasswordPage, ResetPasswordPageViewModel>();
            containerRegistry.RegisterForNavigation<WelcomePage, WelcomePageViewModel>();
            containerRegistry.RegisterForNavigation<NotesPage, NotesViewModel>();
            containerRegistry.RegisterForNavigation<ShiftsPage, ShiftsViewModel>();
            containerRegistry.RegisterForNavigation<ReservationsPage, ReservationsPageViewModel>();
            containerRegistry.RegisterForNavigation<ReservationDayDetailsPage, ReservationDayDetailsPageViewModel>();
            containerRegistry.RegisterForNavigation<SettingsPage, SettingsPageViewModel>();
            containerRegistry.RegisterForNavigation<EmployeesPage, EmployeesPageViewModel>();
            containerRegistry.RegisterForNavigation<EmployeeDetail, EmployeeDetailViewModel>();

            containerRegistry.RegisterPopup<NotePopup, NotePopupViewModel>();
            containerRegistry.RegisterPopup<ShiftPopup, ShiftPopupViewModel>();
            containerRegistry.RegisterPopup<ReservationCNIPopup, ReservationCNIPopupViewModel>();

            containerRegistry.Register<DatabaseServiceRemote>();
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            CrossFirebasePushNotification.Current.OnTokenRefresh += Current_OnTokenRefresh;

            Settings.Theme = Settings.Theme;
            await NavigationService.NavigateTo<LoginPage>(true);
        }

        private void Current_OnTokenRefresh(object source, FirebasePushNotificationTokenEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine($"Token: {e.Token}");
        }
    }
}
