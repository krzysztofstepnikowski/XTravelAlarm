using System;

namespace XTravelAlarm.Services.Storage
{
    public interface IAlarmStorage
    {
        Alarm GetAlarm(Guid alarmId);
    }
}