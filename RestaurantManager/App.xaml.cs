using Prism;
using Prism.DryIoc;
using Prism.Ioc;
using RestaurantManager.Core.DatabaseService;
using RestaurantManager.Core.Authentication;
using RestaurantManager.Extensions;
using RestaurantManager.Pages;
using RestaurantManager.Pages.Authentication.Login;
using RestaurantManager.Pages.Authentication.Signup;
using RestaurantManager.Pages.Reservations;
using RestaurantManager.Popups;
using RestaurantManager.Services;
using Xamarin.Forms;
using XCT.Popups.Prism;

namespace RestaurantManager
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer) : base(initializer) {}

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IPopupService, PopupService>();
            containerRegistry.RegisterSingleton<INoteService, NoteService>();
            containerRegistry.RegisterSingleton<IShiftsService, ShiftsService>();
            
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<SignupPage, SignupPageViewModel>();
            containerRegistry.RegisterForNavigation<WelcomePage, WelcomePageViewModel>();
            containerRegistry.RegisterForNavigation<NotesPage, NotesViewModel>();
            containerRegistry.RegisterForNavigation<ShiftsPage, ShiftsViewModel>();
            containerRegistry.RegisterForNavigation<ReservationsPage, ReservationsPageViewModel>();

            containerRegistry.RegisterPopup<NotePopup, NotePopupViewModel>();
            containerRegistry.RegisterPopup<ShiftPopup, ShiftPopupViewModel>();
            containerRegistry.RegisterPopup<ReservationPopup, ReservationPopupViewModel>();

            containerRegistry.Register<DatabaseServiceRemote>();
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateTo<LoginPage>(true);
        }
    }
}
