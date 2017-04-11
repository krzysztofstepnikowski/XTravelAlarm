using System;
using System.Collections.Generic;
using XTravelAlarm.Models;

namespace XTravelAlarm.Views.Alarms
{
    public interface IAlarmPageFeatures
    {
        IEnumerable<AlarmLocationViewModel> GetAll();
        void Enable(Guid alarmId);
        void Disable(Guid alarmId);
        void Remove(Guid alarmId);

        bool IsEmptyAlarmList();
    }
}