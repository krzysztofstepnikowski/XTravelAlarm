using System;

namespace XTravelAlarm.Features.AlarmRinging.Storage
{
    public interface IAlarmStorage
    {
        Alarm GetAlarm(Guid alarmId);
    }
}