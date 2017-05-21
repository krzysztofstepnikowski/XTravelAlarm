using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Android.Media;
using Xamarin.Forms;
using XTravelAlarm.Droid.Services;
using XTravelAlarm.Features.AlarmRinging;

[assembly: Dependency(typeof(DroidAlarmRinger))]

namespace XTravelAlarm.Droid.Services
{
    public class DroidAlarmRinger : IRinger
    {
        private static MediaPlayer MediaPlayer;

        public void PlaySound()
        {
            var path = "Alarm.mp3";

            try
            {
                var assetFileDescriptor = Forms.Context.Assets.OpenFd(path);

                if (MediaPlayer == null)
                {
                    MediaPlayer = new MediaPlayer();
                }

                else
                {
                    MediaPlayer.Reset();
                    MediaPlayer.SetDataSource(assetFileDescriptor.FileDescriptor, assetFileDescriptor.StartOffset,
                        assetFileDescriptor.Length);
                    MediaPlayer.Prepare();
                    MediaPlayer.Start();
                }
            }

            catch (Exception ex)
            {
                Debug.WriteLine($"Error open assetFileDescriptor {ex.Message}");
            }
        }


        public static void StopPlayingSound(string alarmId)
        {
            try
            {
                MediaPlayer.Stop();
            }

            catch (Exception ex)
            {
                Debug.WriteLine($"Error when sound is stopped: {ex.Message}");
            }
        }
    }
}
