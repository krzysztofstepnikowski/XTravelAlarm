using System.Collections.Generic;
using XTravelAlarm.Features.AlarmList;

namespace XTravelAlarm.Views.AlarmPage
{
    public interface IAlarmPageFeatures
    {
        IEnumerable<Alarm> GetAlarms();
    }
}