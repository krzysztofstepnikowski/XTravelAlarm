using System;

using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Plugin.CurrentActivity;
using Plugin.Geolocator;

namespace XTravelAlarm.Droid
{
    [Application]
    public class MainApplication : Application, Application.IActivityLifecycleCallbacks
    {
        public MainApplication(IntPtr handle, JniHandleOwnership transer)
          : base(handle, transer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();
            RegisterActivityLifecycleCallbacks(this);
            //A great place to initialize Xamarin.Insights and Dependency Services!
        }

        public void OnActivityCreated(Activity activity, Bundle savedInstanceState)
        {
            CrossCurrentActivity.Current.Activity = activity;
            Log.WriteLine(LogPriority.Debug, "ACTIVITY_STATE", "Activity has been created");
        }

        public void OnActivityStarted(Activity activity)
        {
            Log.WriteLine(LogPriority.Debug, "ACTIVITY_STATE", "Activity has been started");
        }

        public void OnActivityResumed(Activity activity)
        {
            CrossCurrentActivity.Current.Activity = activity;
        }

        public void OnActivityPaused(Activity activity)
        {
            Log.WriteLine(LogPriority.Debug, "ACTIVITY_STATE", "Activity has been paused");
        }

        public void OnActivitySaveInstanceState(Activity activity, Bundle outState)
        {
            Log.WriteLine(LogPriority.Debug, "ACTIVITY_STATE", "Activity has been saved instance state");
        }

        public void OnActivityStopped(Activity activity)
        {
            Log.WriteLine(LogPriority.Debug, "ACTIVITY_STATE", "Activity has been stopped");
        }

        public override void OnTerminate()
        {
            base.OnTerminate();
            UnregisterActivityLifecycleCallbacks(this);
            Log.WriteLine(LogPriority.Debug, "ACTIVITY_STATE", "Activity has been terminated");
        }
        
        public async void OnActivityDestroyed(Activity activity)
        {
            await CrossGeolocator.Current.StopListeningAsync();
            Log.WriteLine(LogPriority.Debug, "ACTIVITY_STATE", "Activity has been destroyed");
        }
    }
}
