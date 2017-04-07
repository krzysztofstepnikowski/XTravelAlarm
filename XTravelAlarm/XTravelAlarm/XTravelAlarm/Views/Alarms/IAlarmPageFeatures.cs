using System;
using System.Collections.Generic;
using XTravelAlarm.Features;

namespace XTravelAlarm.Views.Alarms
{
    public interface IAlarmPageFeatures
    {
        IEnumerable<AlarmLocation> GetAll();
        void Add(AlarmLocation alarmLocation);
        AlarmLocation GetById(Guid id);
        void Remove(Guid id);


    }
}