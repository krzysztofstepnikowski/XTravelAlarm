using System;
using System.Collections.Generic;
using System.Linq;

namespace XTravelAlarm.Features.AlarmList
{
    public class AlarmListProvider
    {
        private readonly HashSet<AlarmLocation> alarms;

        public AlarmListProvider(HashSet<AlarmLocation> alarms)
        {
            this.alarms = alarms;
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

        public AlarmLocation GetById(Guid id)
        {
            return alarms.SingleOrDefault(alarm => alarm.Id == id);
            
        }

        public void Remove(Guid id)
        {
            var alarm = GetById(id);

            if (alarm == null)
            {
                throw new Exception("Alarm doesn't exist");
            }

            alarms.Remove(alarm);

        }
    }
}
