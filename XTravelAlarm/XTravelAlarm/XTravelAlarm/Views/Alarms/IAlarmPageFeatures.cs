using System.Collections.Generic;
using XTravelAlarm.Features;

namespace XTravelAlarm.Views.Alarms
{
    public interface IAlarmPageFeatures
    {
        IEnumerable<Location> GetAlarms();
    }
}