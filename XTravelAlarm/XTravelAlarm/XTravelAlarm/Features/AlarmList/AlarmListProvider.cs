using System.Collections.Generic;
using System.Linq;
using XTravelAlarm.Views.Alarms;

namespace XTravelAlarm.Features.AlarmList
{
    public class AlarmListProvider : IAlarmPageFeatures
    {
        private readonly HashSet<Location> alarms;

        public AlarmListProvider(HashSet<Location> alarms)
        {
            this.alarms = alarms;
        }

        public IEnumerable<Location> GetAll()
        {
            return Enumerable.Range(0, alarms.Count)
                .Select(i => new Location()
                {
                    Name = i.ToString()
                }).ToList();
        }

        public void Add(Location alarmLocation)
        {
            alarms.Add(alarmLocation);
        }
    }
}
