using System;
using System.Diagnostics;
using Android.Media;
using Xamarin.Forms;
using XTravelAlarm.Features.AlarmRinging;
using XTravelAlarm.Droid.Services;

[assembly: Dependency(typeof(DroidAlarmRinger))]

namespace XTravelAlarm.Droid.Services
{
    public class DroidAlarmRinger : IRinger
    {
        private static Lazy<MediaPlayer> MediaPlayer = new Lazy<MediaPlayer>();
      
        public void PlaySound()
        {
            var path = "Alarm.mp3";

            try
            {
                var assetFileDescriptor = Forms.Context.Assets.OpenFd(path);
                

                MediaPlayer.Value.Reset();
                MediaPlayer.Value.SetDataSource(assetFileDescriptor.FileDescriptor, assetFileDescriptor.StartOffset,
                    assetFileDescriptor.Length);
                MediaPlayer.Value.Prepare();
                MediaPlayer.Value.Start();
            }

            catch (Exception ex)
            {
                Debug.WriteLine("File could not be loaded: {0}", ex.Message);
            }
        }


        public void StopPlaySound(string alarmId)
        {
            try
            {
                if (MediaPlayer.Value.IsPlaying)
                {
                    MediaPlayer.Value.Stop();
                }
            }

            catch (Exception ex)
            {
                Debug.WriteLine($"Error when sound is stopped: {ex.Message}");
            }
        }
    }
}
