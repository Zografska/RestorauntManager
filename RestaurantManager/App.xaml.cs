﻿using Prism;
using Prism.Ioc;
using RestaurantManager.Core.DatabaseService;
using RestaurantManager.Extensions;
using RestaurantManager.Model;
using RestaurantManager.Pages;
using RestaurantManager.Pages.Employees;
using RestaurantManager.Pages.Reservations;
using RestaurantManager.Popups;
using RestaurantManager.Services;
using Xamarin.Forms;
using XCT.Popups.Prism;

namespace RestaurantManager
{
    public partial class App
    {
        public App() : this(null) {}
        public App(IPlatformInitializer initializer) : base(initializer) {}

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IPopupService, PopupService>();
            containerRegistry.RegisterSingleton<INoteService, NoteService>();
            containerRegistry.RegisterSingleton<IShiftsService, ShiftsService>();
            containerRegistry.RegisterSingleton<IEmployeeService, EmployeeService>();
            
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<WelcomePage, WelcomePageViewModel>();
            containerRegistry.RegisterForNavigation<NotesPage, NotesViewModel>();
            containerRegistry.RegisterForNavigation<ShiftsPage, ShiftsViewModel>();
            containerRegistry.RegisterForNavigation<ReservationsPage, ReservationsPageViewModel>();
            containerRegistry.RegisterForNavigation<EmployeesPage, EmployeesViewModel>();

            containerRegistry.RegisterPopup<NotePopup, NotePopupViewModel>();
            containerRegistry.RegisterPopup<ShiftPopup, ShiftPopupViewModel>();
            containerRegistry.RegisterPopup<ReservationPopup, ReservationPopupViewModel>();
            containerRegistry.RegisterPopup<EmployeePopup, EmployeePopupViewModel>();

            containerRegistry.Register<DatabaseServiceRemote>();
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateTo<WelcomePage>(true);
        }
    }
}
