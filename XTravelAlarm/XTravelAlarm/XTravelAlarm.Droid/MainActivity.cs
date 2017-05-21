using Acr.UserDialogs;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Prism.Unity;
using Microsoft.Practices.Unity;
using Xamarin.Forms;
using XTravelAlarm.Droid.Services;
using XTravelAlarm.Features.AlarmRinging;

namespace XTravelAlarm.Droid
{
    [Activity(Label = "XTravel Alarm", Icon = "@drawable/ic_launcher", MainLauncher = true,
        ScreenOrientation = ScreenOrientation.Portrait,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.tabs;
            ToolbarResource = Resource.Layout.toolbar;

            base.OnCreate(bundle);


            global::Xamarin.Forms.Forms.Init(this, bundle);
            Xamarin.FormsMaps.Init(this, bundle);
            UserDialogs.Init(this);
            LoadApplication(new App(new AndroidInitializer()));

            ProcessIntentAction(Intent);
        }

        protected override void OnNewIntent(Intent intent)
        {
            ProcessIntentAction(intent);
            base.OnNewIntent(intent);
        }

        private void ProcessIntentAction(Intent intent)
        {
            
            if (intent.Action != null)
            {
                switch (intent.Action)
                {
                    case "TURN_OFF_ALARM_ACTION":
                        Bundle extras = intent.Extras;
                        if (extras != null)
                        {
                            if (extras.ContainsKey("alarmId"))
                            {
                                var alarmId = extras.GetString("alarmId");
                                var notifyId = extras.GetInt("notifyId");
                                var activity = Forms.Context as Activity;

                                DroidAlarmRinger.StopPlayingSound(alarmId);
                                DroidNotificationService.CancelNotification(activity,notifyId);
                                System.Console.WriteLine($"Alarm o id: {alarmId} został wyłączony");
                            }
                        }
                        break;
                }
            }
        }
    }


    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<INotificationService, DroidNotificationService>();
        }
    }
}

