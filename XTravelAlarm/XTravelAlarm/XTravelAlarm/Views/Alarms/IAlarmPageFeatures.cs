using System.Collections.Generic;
using XTravelAlarm.Features.AlarmList;

namespace XTravelAlarm.Views.Alarms
{
    public interface IAlarmPageFeatures
    {
        IEnumerable<Alarm> GetAlarms();
    }
}