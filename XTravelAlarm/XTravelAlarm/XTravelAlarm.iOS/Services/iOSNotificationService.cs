using System;
using Foundation;
using UIKit;
using Xamarin.Forms;
using XTravelAlarm.Features.AlarmRinging;
using XTravelAlarm.iOS.Services;

[assembly: Dependency(typeof(iOSNotificationService))]
namespace XTravelAlarm.iOS.Services
{
    public class iOSNotificationService : INotificationService
    {
        public void Show(string title, string message, Guid alarmId)
        {
            var notification = new UILocalNotification();
            NSDate.FromTimeIntervalSinceNow(15);
            notification.AlertAction = title;
            notification.AlertBody = message;
            UIApplication.SharedApplication.ScheduleLocalNotification(notification);

        }

//        public void Register()
//        {
//            if (UIDevice.CurrentDevice.CheckSystemVersion(10, 0))
//            {
//                UNUserNotificationCenter.Current.GetNotificationSettings(HandleNotificationSettings);
//            }
//            else
//            {
//                var pushSettings = UIUserNotificationSettings.GetSettingsForTypes(
//                   UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound,
//                   new NSSet());
//
//                UIApplication.SharedApplication.RegisterUserNotificationSettings(pushSettings);
//                UIApplication.SharedApplication.RegisterForRemoteNotifications();
//            }
//        }
//
//        private void HandleNotificationSettings(UNNotificationSettings settings)
//        {
//            // Sample how to check specific authorizaiton status
//            // var alertsAllowed = (settings.AlertSetting == UNNotificationSetting.Enabled);
//
//            UNUserNotificationCenter.Current.RequestAuthorization(UNAuthorizationOptions.Alert |
//                                                                  UNAuthorizationOptions.Badge |
//                                                                  UNAuthorizationOptions.Sound,
//                                                                  HandlePushAuthorization);
//
//            UNUserNotificationCenter.Current.Delegate = new PushNotificationCenterDelegate();
//        }
    }
}
