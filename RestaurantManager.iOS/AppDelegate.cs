﻿using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using Plugin.GoogleClient;
using Prism;
using Prism.Ioc;
using RestaurantManager.Core.Authentication;
using RestaurantManager.iOS.Core;
using RestaurantManager.Services;
using UIKit;
using UserNotifications;

namespace RestaurantManager.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate, IPlatformInitializer
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            GoogleClientManager.Initialize();
            LoadApplication(new App(this));
            Firebase.Core.App.Configure();
            UNUserNotificationCenter.Current.Delegate = new iOSNotificationReceiver();
            return base.FinishedLaunching(app, options);
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IAuthService, AuthiOS>();
            containerRegistry.Register<IPushNotificationsLocal, PushNotificationsLocaliOS>();
        }

        public override bool OpenUrl(UIApplication app, NSUrl url, NSDictionary options)
        {
            return GoogleClientManager.OnOpenUrl(app, url, options);
        }
    }
}
