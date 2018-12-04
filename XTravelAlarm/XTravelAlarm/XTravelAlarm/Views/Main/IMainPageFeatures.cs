using System.Threading.Tasks;
using XTravelAlarm.Models;

namespace XTravelAlarm.Views.Main
{
    public interface IMainPageFeatures
    {
        Task AddAlarmAsync(AlarmLocation alarmLocation);
    }
}