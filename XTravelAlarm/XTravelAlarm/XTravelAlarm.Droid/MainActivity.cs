using System;
using Acr.UserDialogs;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Xamarin.Forms;
using XTravelAlarm.Droid.Services;
using XTravelAlarm.Views.Alarms;
using Android.Widget;
using Plugin.CurrentActivity;
using Plugin.Permissions;
using Prism;
using Prism.Ioc;
using XTravelAlarm.PlatformServices;

namespace XTravelAlarm.Droid
{
    [Activity(Label = "XTravel Alarm", Icon = "@drawable/ic_launcher", MainLauncher = true,
        ScreenOrientation = ScreenOrientation.Portrait,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity, IPlatformInitializer
    {
        private IContainerProvider _container;

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.tabs;
            ToolbarResource = Resource.Layout.toolbar;

            base.OnCreate(bundle);
            Forms.Init(this, bundle);
            Xamarin.FormsMaps.Init(this, bundle);
            UserDialogs.Init(this);
            CrossCurrentActivity.Current.Init(this,bundle);
            Xamarin.Essentials.Platform.Init(this, bundle);

            var application = new App(this);
            _container = application.Container;

            LoadApplication(application);
            ProcessIntentAction(Intent);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
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
                                var alarmPageFeatures = _container.Resolve<IAlarmPageFeatures>();

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

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterInstance(CrossCurrentActivity.Current);
            containerRegistry.Register<IRinger, DroidAlarmRinger>();
            containerRegistry.Register<INotificationService, DroidNotificationService>();
        }
    }
}
