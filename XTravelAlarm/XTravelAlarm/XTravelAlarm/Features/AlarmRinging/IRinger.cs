using System.Threading.Tasks;

namespace XTravelAlarm.Features.AlarmRinging
{
    public interface IRinger
    {
        Task PlaySoundAsync(string filename);
    }
}