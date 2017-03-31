using System.Collections.Generic;
using XTravelAlarm.Features;

namespace XTravelAlarm.Views.Alarms
{
    public interface IAlarmPageFeatures
    {
        IEnumerable<AlarmLocation> GetAll();
        void Add(AlarmLocation alarmLocation);
        void Enable(AlarmLocation alarmLocation);
        void Disable(AlarmLocation alarmLocation);


    }
}