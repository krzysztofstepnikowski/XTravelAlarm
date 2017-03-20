using Android.App;
using Android.Widget;
using Xamarin.Forms;
using XTravelAlarm.Droid.Services;
using XTravelAlarm.Features;

[assembly: Dependency(typeof(DroidAlarmRinger))]

namespace XTravelAlarm.Droid.Services
{
    public class DroidAlarmRinger : IRinger
    {
        public void Ring()
        {
            var activity = Forms.Context as Activity;
            Toast.MakeText(activity, "Alarm zosta³ uruchomiony", ToastLength.Short).Show();
        }
    }
}