using Foundation;
using UIKit;
using Prism;
using Prism.Ioc;
using Xamarin;
using XTravelAlarm.iOS.Services;
using XTravelAlarm.PlatformServices;
using UserNotifications;

namespace XTravelAlarm.iOS
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
            FormsMaps.Init();

            //If the device is running iOS 8, if so we are required to ask for the user's permission to receive notifications       
            if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
            {
                var notificationSettings = UIUserNotificationSettings.GetSettingsForTypes(UIUserNotificationType.Alert
                                           | UIUserNotificationType.Badge | UIUserNotificationType.Sound, null);

                app.RegisterUserNotificationSettings(notificationSettings);
            }

            if (UIDevice.CurrentDevice.CheckSystemVersion(10, 0))
            {
                UNUserNotificationCenter.Current.RequestAuthorization(UNAuthorizationOptions.Alert | UNAuthorizationOptions.Badge | UNAuthorizationOptions.Sound,
                    (approved, error) => { });
                UNUserNotificationCenter.Current.Delegate = new UserNotificationCenterDelegate();
            }

            LoadApplication(new App(this));

            return base.FinishedLaunching(app, options);
        }

        public override void ReceivedLocalNotification(UIApplication application, UILocalNotification notification)
        {
            UIAlertController okayAlertController = UIAlertController.Create(notification.AlertAction,
                notification.AlertBody, UIAlertControllerStyle.Alert);
            okayAlertController.AddAction(UIAlertAction.Create("Wyłącz", UIAlertActionStyle.Default, null));
            UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(okayAlertController, true,
                null);
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<ILocalNotificationService, iOSLocalNotificationService>();
        }
    }
}
