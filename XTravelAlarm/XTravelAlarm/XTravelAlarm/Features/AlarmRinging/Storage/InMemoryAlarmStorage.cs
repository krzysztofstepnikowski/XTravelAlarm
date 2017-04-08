using System;
using XTravelAlarm.Features.AlarmList;

namespace XTravelAlarm.Features.AlarmRinging.Storage
{
    public class InMemoryAlarmStorage : IAlarmStorage
    {
        private readonly AlarmListProvider alarmListProvider;

        public InMemoryAlarmStorage(AlarmListProvider alarmListProvider)
        {
            this.alarmListProvider = alarmListProvider;
        }


        public Alarm GetAlarm(Guid alarmId)
        {
            var alarm = alarmListProvider.GetById(alarmId);

            return alarm;
        }
    }
}
