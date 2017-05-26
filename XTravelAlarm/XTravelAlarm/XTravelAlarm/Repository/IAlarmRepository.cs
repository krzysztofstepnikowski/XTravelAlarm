using System;
using System.Collections.Generic;
using XTravelAlarm.Features;

namespace XTravelAlarm.Repository
{
    public interface IAlarmRepository
    {
        void Add(AlarmLocation alarmLocation);
        void Remove(Guid id);
        IEnumerable<AlarmLocation> GetAll();
        AlarmLocation GetById(Guid id);
    }
}
