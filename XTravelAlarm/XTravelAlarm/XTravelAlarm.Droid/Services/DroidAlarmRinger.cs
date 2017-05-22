using System;
using System.Diagnostics;
using Android.Media;
using Xamarin.Forms;
using XTravelAlarm.Features.AlarmRinging;


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


                MediaPlayer.Reset();
                MediaPlayer.SetDataSource(assetFileDescriptor.FileDescriptor, assetFileDescriptor.StartOffset,
                    assetFileDescriptor.Length);
                MediaPlayer.Prepare();
                MediaPlayer.Start();
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
