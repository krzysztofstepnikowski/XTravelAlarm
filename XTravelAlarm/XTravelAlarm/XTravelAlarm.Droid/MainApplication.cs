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
           
            Log.WriteLine(LogPriority.Debug, "ACTIVITY_STATE", "Activity has been created");
        }

        public void OnActivityStarted(Activity activity)
        {
            CrossCurrentActivity.Current.Activity = activity;
            CrossGeolocator.Current.StartListeningAsync(minTime: 1000, minDistance: 1000);
            Log.WriteLine(LogPriority.Debug, "ACTIVITY_STATE", "Activity has been started");
        }

        public void OnActivityResumed(Activity activity)
        {
            Log.WriteLine(LogPriority.Debug, "ACTIVITY_STATE", "Activity has been resumed");

        }

        public async void OnActivityPaused(Activity activity)
        {
            CrossCurrentActivity.Current.Activity = activity;
            await CrossGeolocator.Current.StartListeningAsync(minTime: 1000, minDistance: 1000);
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
        }

       

        public async void OnActivityDestroyed(Activity activity)
        {
            await CrossGeolocator.Current.StopListeningAsync();
            Log.WriteLine(LogPriority.Debug, "ACTIVITY_STATE", "Activity has been destroyed");
        }
    }
}