using System.Threading.Tasks;
using XTravelAlarm.Features;

namespace XTravelAlarm.Views.Main
{
    public interface IMainPageFeatures
    {
        Task AddAlarmAsync(AlarmLocation alarmLocation);
    }
}