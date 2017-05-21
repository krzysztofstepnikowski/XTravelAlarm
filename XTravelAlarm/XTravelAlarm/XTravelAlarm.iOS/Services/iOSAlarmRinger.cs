using System.IO;
using System.Threading.Tasks;
using AVFoundation;
using Foundation;
using Xamarin.Forms;
using XTravelAlarm.Features.AlarmRinging;
using XTravelAlarm.iOS.Services;


[assembly: Dependency(typeof(iOSAlarmRinger))]

namespace XTravelAlarm.iOS.Services
{
    public class iOSAlarmRinger : NSObject, IRinger, IAVAudioPlayerDelegate
    {
        private AVAudioPlayer player;

        public void PlaySound()
        {
            string path = NSBundle.MainBundle.PathForResource(Path.GetFileNameWithoutExtension("Alarm.mp3"),
                Path.GetExtension("Alarm.mp3"));

            var url = NSUrl.FromString(path);
            player = AVAudioPlayer.FromUrl(url);

            player.FinishedPlaying += (object sender, AVStatusEventArgs e) => { player = null; };

            player.Play();
        }
    }
}
