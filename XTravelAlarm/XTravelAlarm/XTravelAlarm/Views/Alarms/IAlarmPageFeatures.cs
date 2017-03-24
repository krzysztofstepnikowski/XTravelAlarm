using System.Collections.Generic;
using System.Threading.Tasks;
using XTravelAlarm.Features;

namespace XTravelAlarm.Views.Alarms
{
    public interface IAlarmPageFeatures
    {
        IEnumerable<Location> GetAll();
        Task Add(Location alarmLocation);

    }
}