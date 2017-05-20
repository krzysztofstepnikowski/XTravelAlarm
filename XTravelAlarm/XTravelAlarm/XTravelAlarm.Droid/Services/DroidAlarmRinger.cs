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
        public static MediaPlayer MediaPlayer;

        public Task PlaySoundAsync(string filename)
        {
            MediaPlayer = new MediaPlayer();
            var taskCompletionSource = new TaskCompletionSource<bool>();


            var path = filename;
            Android.Content.Res.AssetFileDescriptor assetFileDescriptor = null;


            try
            {
                assetFileDescriptor = Forms.Context.Assets.OpenFd(path);
            }

            catch (Exception ex)
            {
                Debug.WriteLine($"Error open assetFileDescriptor {ex.Message}");
            }

            if (assetFileDescriptor != null)
            {
                MediaPlayer.Prepared += (sender, args) => { MediaPlayer.Start(); };

                MediaPlayer.SetDataSource(assetFileDescriptor.FileDescriptor, assetFileDescriptor.StartOffset,
                    assetFileDescriptor.Length);
                MediaPlayer.PrepareAsync();
            }

            return taskCompletionSource.Task;
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
