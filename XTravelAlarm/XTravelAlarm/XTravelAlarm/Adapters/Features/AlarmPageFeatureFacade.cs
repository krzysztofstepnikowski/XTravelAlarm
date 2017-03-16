using System.Collections.Generic;
using System.Linq;
using XTravelAlarm.Features;
using XTravelAlarm.Features.AlarmList;
using XTravelAlarm.Views.Alarms;

namespace XTravelAlarm.Adapters.Features
{
    public class AlarmPageFeatureFacade : IAlarmPageFeatures
    {
        private readonly AlarmListProvider _alarmListProvider;

        public AlarmPageFeatureFacade(AlarmListProvider alarmListProvider)
        {
            _alarmListProvider = alarmListProvider;
        }

        public IEnumerable<Location> GetAll()
        {
            return _alarmListProvider.GetAll().Select(alarm => new Location()
            {
                Name = alarm.Name,
                Distance = alarm.Distance
            }).ToList();
        }

        public void Add(Location alarmLocation)
        {
            _alarmListProvider.Add(alarmLocation);
        }
    }
}
