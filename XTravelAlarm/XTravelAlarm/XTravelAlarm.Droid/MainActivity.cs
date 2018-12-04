using System;
using Acr.UserDialogs;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Prism.Unity;
using Microsoft.Practices.Unity;
using Xamarin.Forms;
using XTravelAlarm.Droid.Services;
using XTravelAlarm.Views.Alarms;
using Android.Widget;
using XTravelAlarm.PlatformServices;

namespace XTravelAlarm.Droid
{
    [Activity(Label = "XTravel Alarm", Icon = "@drawable/ic_launcher", MainLauncher = true,
        ScreenOrientation = ScreenOrientation.Portrait,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        private IUnityContainer container;

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.tabs;
            ToolbarResource = Resource.Layout.toolbar;

            base.OnCreate(bundle);

            

            Forms.Init(this, bundle);
            Xamarin.FormsMaps.Init(this, bundle);
            UserDialogs.Init(this);

            var application = new App(new AndroidInitializer());
            container = application.Container;

            LoadApplication(application);

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
                                var droidAlarmRinger = new DroidAlarmRinger();
                                var alarmPageFeatures = container.Resolve<IAlarmPageFeatures>();

                                droidAlarmRinger.StopPlaySound(alarmId);
                                DroidNotificationService.CancelNotification(activity,notifyId);
                                alarmPageFeatures.Disable(Guid.Parse(alarmId));

                                Toast.MakeText(activity, "Alarm wyłączony", ToastLength.Short).Show();
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
            container.RegisterType<IRinger, DroidAlarmRinger>();
            container.RegisterType<INotificationService, DroidNotificationService>();
        }
    }
}

