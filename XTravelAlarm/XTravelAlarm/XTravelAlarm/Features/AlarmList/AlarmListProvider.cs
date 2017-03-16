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
            return alarms.Select(x => new Location
            {
                Name = x.Name,
                Distance = x.Distance
            }).ToList();
        }

        public void Add(Location alarmLocation)
        {
            alarms.Add(alarmLocation);
        }
    }
}
