using System;
using System.Collections.Generic;
using System.Linq;
using XTravelAlarm.Features;
using XTravelAlarm.Services.Storage;

namespace XTravelAlarm.Services
{
    public class InMemoryAlarmStorage : IAlarmStorage
    {
        private readonly HashSet<AlarmLocation> alarms;

        public InMemoryAlarmStorage(HashSet<AlarmLocation> alarms)
        {
            this.alarms = alarms;
        }


        public Alarm GetAlarm(Guid alarmId)
        {
            var alarm = GetById(alarmId);

            return new Alarm(alarm.Position, alarm.Distance);
        }

        public IEnumerable<AlarmLocation> GetAll()
        {
            return alarms.Select(x => new AlarmLocation
            {
                Name = x.Name,
                Distance = x.Distance,
                IsRunning = x.IsRunning
            }).ToList();
        }

        public void Add(AlarmLocation alarmLocation)
        {
            alarms.Add(alarmLocation);
        }

        public AlarmLocation GetById(Guid Id)
        {
            var alarmId = alarms.SingleOrDefault(alarm => alarm.Id == Id);

            return alarmId;
        }
    }
}
