using System;
using System.Collections.Generic;
using System.Linq;
using XTravelAlarm.Features;
using XTravelAlarm.Features.AlarmRinging.Storage;

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
                Id = x.Id,
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

        public void Remove(Guid Id)
        {
            var alarm = GetById(Id);

            if (alarm == null)
            {
                throw new Exception("Alarm null");
            }

            else
            {
                alarms.Remove(alarm);
            }
        }

        public bool IsEmptyStorage()
        {
            return alarms.Count == 0;
        }
    }
}
