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
        public void Show(string title, string message, DateTime time)
        {
            var notification = new UILocalNotification();
            NSDate.FromTimeIntervalSinceNow(time.Millisecond);
            notification.AlertAction = title;
            notification.AlertBody = message;
            UIApplication.SharedApplication.ScheduleLocalNotification(notification);

        }
    }
}
