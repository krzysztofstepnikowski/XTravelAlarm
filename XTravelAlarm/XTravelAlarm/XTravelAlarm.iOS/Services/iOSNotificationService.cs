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
            NSDate.FromTimeIntervalSinceNow(Double.MinValue);
            notification.AlertAction = title;
            notification.AlertBody = message;
            UIApplication.SharedApplication.ScheduleLocalNotification(notification);
        }
    }
}
