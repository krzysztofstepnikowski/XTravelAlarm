using System;
using Android.App;
using Android.Content;
using Xamarin.Forms;
using XTravelAlarm.Droid.Services;
using XTravelAlarm.Features.AlarmRinging;

[assembly: Dependency(typeof(DroidNotificationService))]
namespace XTravelAlarm.Droid.Services
{
    public class DroidNotificationService : INotificationService
    {
        public void Show(string title, string message, DateTime time)
        {
            var activity = Forms.Context as Activity;
            Notification.Builder builder = new Notification.Builder(activity)
                .SetContentTitle(title)
                .SetContentText(message)
                .SetSmallIcon(Resource.Drawable.ic_speaker_dark);
            // Build the notification:
            Notification notification = builder.Build();

            // Get the notification manager:
            NotificationManager notificationManager =activity.GetSystemService(Context.NotificationService) as NotificationManager;

            // Publish the notification:
            const int notificationId = 0;
            notificationManager.Notify(notificationId, notification);

            builder.SetWhen(time.Millisecond);
        }
    }
}