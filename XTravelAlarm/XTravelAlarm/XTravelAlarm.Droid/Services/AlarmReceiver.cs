using Android.Content;
using Android.Widget;

namespace XTravelAlarm.Droid.Services
{
    public class AlarmReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            Toast.MakeText(context,"I'm running",ToastLength.Short).Show();
        }
    }
}