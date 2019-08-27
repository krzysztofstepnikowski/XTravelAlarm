using System;
using System.IO;
using System.Xml.Serialization;
using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Support.V4.App;
using Java.Lang;
using Xamarin.Forms;
using XTravelAlarm.Droid.Services;
using XTravelAlarm.Models;
using XTravelAlarm.PlatformServices;

[assembly: Dependency(typeof(DroidLocalNotificationService))]

namespace XTravelAlarm.Droid.Services
{
    public class DroidLocalNotificationService : ILocalNotificationService
    {
        public const int NotificationId = 234;
        private readonly DateTime date = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public void LocalNotification(string title, string message, Guid alarmId)
        {
            long repeateForMinute = 60000; // In milliseconds      
            long totalMilliSeconds = (long)(DateTime.Now.ToUniversalTime() - date).TotalMilliseconds;

            if (totalMilliSeconds < JavaSystem.CurrentTimeMillis())
            {
                totalMilliSeconds = totalMilliSeconds + repeateForMinute;
            }
            var intent = CreateIntent(0);
            var notification = new LocalNotificationModel
            {
                Title = title,
                Body = message,
                Id = 0
            };

            var serializedNotification = SerializeNotification(notification);
            intent.PutExtra(ScheduledAlarmHandler.Key, serializedNotification);

            var pendingIntent = PendingIntent.GetBroadcast(Android.App.Application.Context, NotificationId, intent,
                                PendingIntentFlags.Immutable);

            var alarmManager = GetAlarmManager();
            alarmManager.SetRepeating(AlarmType.RtcWakeup, totalMilliSeconds, AlarmManager.IntervalDay, pendingIntent);
        }

        public static Intent GetLauncherActivity()
        {
            var packageName = Android.App.Application.Context.PackageName;
            return Android.App.Application.Context.PackageManager.GetLaunchIntentForPackage(packageName);
        }

        private Intent CreateIntent(int id)
        {
            return new Intent(Android.App.Application.Context, typeof(ScheduledAlarmHandler)).SetAction($"LocalNotifier {id}");
        }

        private AlarmManager GetAlarmManager()
        {
            var alarmManager = Android.App.Application.Context.GetSystemService(Context.AlarmService) as AlarmManager;
            return alarmManager;
        }

        private string SerializeNotification(LocalNotificationModel notification)
        {
            var xmlSerializer = new XmlSerializer(notification.GetType());

            using (var stringWriter = new StringWriter())
            {
                xmlSerializer.Serialize(stringWriter, notification);
                return stringWriter.ToString();
            }
        }

        public void CancelNotification(int notifyId)
        {
            var intent = CreateIntent(notifyId);
            var pendingIntent = PendingIntent.GetBroadcast(Android.App.Application.Context, 0, intent,
                                PendingIntentFlags.Immutable);
            var alarmManager = GetAlarmManager();
            alarmManager.Cancel(pendingIntent);

            var notificationManager = NotificationManagerCompat.From(Android.App.Application.Context);
            notificationManager.CancelAll();
            notificationManager.Cancel(notifyId);
        }
    }

    [BroadcastReceiver(Enabled = true, Label = "Local Notifications Broadcast Receiver")]
    public class ScheduledAlarmHandler : BroadcastReceiver
    {
        public const string Key = "alarmId";
        private const string ChannelId = "my_channel_01";
        private const string ChannelName = "Primary Channel";

        public override void OnReceive(Context context, Intent intent)
        {
            var notificationManager = (NotificationManager)Android.App.Application.Context.GetSystemService(Context.NotificationService);
            var extra = intent.GetStringExtra(Key);
            var notification = DeserializeNotification(extra);
            if (notificationManager != null)
            {
                if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
                {
                    var channel = new NotificationChannel(ChannelId, ChannelName, (NotificationImportance)NotificationManagerCompat.ImportanceHigh);
                    notificationManager.CreateNotificationChannel(channel);
                }

                //Bulding notification       
                var builder = new NotificationCompat.Builder(Android.App.Application.Context, ChannelId)
                    .SetContentTitle(notification.Title)
                    .SetContentText(notification.Body)
                    .SetSmallIcon(Android.Resource.Drawable.IcNotificationOverlay)
                    .SetBadgeIconType(Android.Resource.Drawable.IcDialogAlert)
                    .SetAutoCancel(true);

                var resultIntent = DroidLocalNotificationService.GetLauncherActivity();
                resultIntent.SetFlags(ActivityFlags.NewTask | ActivityFlags.ClearTask);
                var stackBuilder = Android.Support.V4.App.TaskStackBuilder.Create(Android.App.Application.Context);
                stackBuilder.AddNextIntent(resultIntent);


                var resultPendingIntent =
                    stackBuilder.GetPendingIntent(DroidLocalNotificationService.NotificationId, (int)PendingIntentFlags.Immutable);
                builder.SetContentIntent(resultPendingIntent);

                // Sending notification       
                notificationManager.Notify(DroidLocalNotificationService.NotificationId, builder.Build());
            }
        }

        private LocalNotificationModel DeserializeNotification(string extra)
        {
            var xmlSerializer = new XmlSerializer(typeof(LocalNotificationModel));
            using (var stringReader = new StringReader(extra))
            {
                var notification = (LocalNotificationModel)xmlSerializer.Deserialize(stringReader);
                return notification;
            }
        }
    }
}