using System;
using Android.App;
using Android.Content;
using Android.Support.V4.App;
using Android.Util;
using Xamarin.Forms;
using XTravelAlarm.Droid.Services;
using XTravelAlarm.Features.AlarmRinging;

[assembly: Dependency(typeof(DroidNotificationService))]

namespace XTravelAlarm.Droid.Services
{
    public class DroidNotificationService : INotificationService
    {
        
        public void Show(string title, string message, Guid alarmId)
        {
            var activity = Forms.Context as Activity;
            var intent = new Intent(activity, typeof(MainActivity));
            intent.SetFlags(ActivityFlags.ClearTop | ActivityFlags.SingleTop);
            intent.SetAction("TURN_OFF_ALARM_ACTION");
            intent.PutExtra("alarmId", alarmId.ToString());


            Log.WriteLine(LogPriority.Debug, "LOG", $"AlarmId to MainActivity= {alarmId}");

            var pendingIntent = PendingIntent.GetActivity(activity, 0, intent, PendingIntentFlags.UpdateCurrent);

            // Build the notification:
            Notification notification = new NotificationCompat.Builder(activity)
                .SetContentTitle(title)
                .SetContentText(message)
                .SetSmallIcon(Resource.Drawable.ic_notification_white)
                .SetContentIntent(pendingIntent)
                .SetAutoCancel(true)
                .AddAction(new NotificationCompat.Action(Resource.Drawable.ic_alarm_off,
                    "Wy³¹cz",
                    PendingIntent.GetActivity(activity, 0, intent, PendingIntentFlags.UpdateCurrent)))
                .Build();


            // Get the notification manager:
            NotificationManager notificationManager =
                activity.GetSystemService(Context.NotificationService) as NotificationManager;


            // Publish the notification:
            const int notificationId = 0;
            notificationManager.Notify(notificationId, notification);
        }
    }
}