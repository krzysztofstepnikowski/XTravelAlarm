using Foundation;
using UIKit;
using Prism.Unity;
using Microsoft.Practices.Unity;
using Xamarin;
using XTravelAlarm.Features.AlarmRinging;
using XTravelAlarm.iOS.Services;
using XTravelAlarm.Views.Alarms;

namespace XTravelAlarm.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //

        private IUnityContainer container;
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            FormsMaps.Init();

            var application = new App(new iOSInitializer());
            container = application.Container;

            LoadApplication(application);

            return base.FinishedLaunching(app, options);
        }

        public override void ReceivedLocalNotification(UIApplication application, UILocalNotification notification)
        {
            UIAlertController okayAlertController = UIAlertController.Create(notification.AlertAction,
                notification.AlertBody, UIAlertControllerStyle.Alert);
            okayAlertController.AddAction(UIAlertAction.Create("Wyłącz", UIAlertActionStyle.Default, alertAction=>TurnOffAlarm()));
            UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(okayAlertController, true,
                null);
        }

        private void TurnOffAlarm()
        {
            var alarmPageFeatures = container.Resolve<IAlarmPageFeatures>();
            var iOSAlarmRinger = new iOSAlarmRinger();

        }


    }

    public class iOSInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IRinger, iOSAlarmRinger>();
            container.RegisterType<INotificationService, iOSNotificationService>();
        }
    }
}
