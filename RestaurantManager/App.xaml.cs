using Prism;
using Prism.Ioc;
using RestaurantManager.Extensions;
using RestaurantManager.Pages;
using Xamarin.Forms;

namespace RestaurantManager
{
    public partial class App
    {
        public App() : this(null) {}
        public App(IPlatformInitializer initializer) : base(initializer) {}

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<WelcomePage, WelcomePageViewModel>();
            containerRegistry.RegisterForNavigation<NotesPage, NotesViewModel>();
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateTo<WelcomePage>(true);
        }
    }
}
