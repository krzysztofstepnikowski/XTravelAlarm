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

        public Action OnFinishedPlaying { get; set; }


        public Task PlaySoundAsync(string filename, Guid alarmId)
        {
            MediaPlayer = new MediaPlayer();
            var taskCompletionSource = new TaskCompletionSource<bool>();

            if (MediaPlayer != null)
            {
                MediaPlayer.Completion -= MediaPlayer_Completion;
                MediaPlayer.Stop();
            }

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
               
                MediaPlayer.Prepared += (sender, args) =>
                {
                    MediaPlayer.Start();
                    MediaPlayer.Completion += MediaPlayer_Completion;
                };

                MediaPlayer.SetDataSource(assetFileDescriptor.FileDescriptor, assetFileDescriptor.StartOffset,
                    assetFileDescriptor.Length);
                MediaPlayer.PrepareAsync();
            }

            return taskCompletionSource.Task;
        }


        private void MediaPlayer_Completion(object sender, EventArgs e)
        {
            OnFinishedPlaying?.Invoke();
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
