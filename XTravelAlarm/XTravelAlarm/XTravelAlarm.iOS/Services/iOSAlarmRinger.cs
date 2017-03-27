using UIKit;
using Xamarin.Forms;
using XTravelAlarm.Features;
using XTravelAlarm.iOS.Services;


[assembly:Dependency(typeof(iOSAlarmRinger))]
namespace XTravelAlarm.iOS.Services
{
    public class iOSAlarmRinger : IRinger
    {
        public void Ring()
        {
            var infoAlert = new UIAlertView("","Obudź się!",null,"OK",null);
            infoAlert.Show();
        }
    }
}
