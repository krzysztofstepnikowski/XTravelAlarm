using System;
using System.Linq;
using Foundation;
using UIKit;
using Xamarin.Forms;
using XTravelAlarm.iOS.Services;
using XTravelAlarm.PlatformServices;

[assembly: Dependency(typeof(iOSLocalNotificationService))]
namespace XTravelAlarm.iOS.Services
{
    public class iOSLocalNotificationService : ILocalNotificationService
    {
        private const string Key = "LocalNotificationKey";

        public void LocalNotification(string title, string message, Guid alarmId)
        {
            var notification = new UILocalNotification
            {
                AlertTitle = title,
                AlertBody = message,
                SoundName = UILocalNotification.DefaultSoundName,
                UserInfo = NSDictionary.FromObjectAndKey(NSObject.FromObject(0), NSObject.FromObject(Key))
            };

            UIApplication.SharedApplication.ScheduleLocalNotification(notification);
        }

        public void CancelNotification(int notifyId)
        {
            var notifications = UIApplication.SharedApplication.ScheduledLocalNotifications;
            var notification = notifications.Where(n => n.UserInfo.ContainsKey(NSObject.FromObject(Key)))
                .FirstOrDefault(n => n.UserInfo[Key].Equals(NSObject.FromObject(0)));
            UIApplication.SharedApplication.CancelAllLocalNotifications();

            if (notification != null)
            {
                UIApplication.SharedApplication.CancelLocalNotification(notification);
                UIApplication.SharedApplication.CancelAllLocalNotifications();
            }
        }
    }
}
