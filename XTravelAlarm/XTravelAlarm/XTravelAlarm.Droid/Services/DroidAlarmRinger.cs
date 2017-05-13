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
        public Task PlaySoundAsync(string filename)
        {
            var player = new MediaPlayer();

            var taskCompletionSource = new TaskCompletionSource<bool>();

            var fileDescriptor = Xamarin.Forms.Forms.Context.Assets.OpenFd(filename);

            player.Prepared += (s, e) => {
                player.Start();
            };

            player.Completion += (sender, e) => {
                taskCompletionSource.SetResult(true);
            };

            // Start playing
            player.SetDataSource(fileDescriptor.FileDescriptor);
            player.Prepare();

            return taskCompletionSource.Task;
        }
    }
}