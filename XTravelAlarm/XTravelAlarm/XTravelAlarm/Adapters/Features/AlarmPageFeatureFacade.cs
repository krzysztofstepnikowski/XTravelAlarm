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

        public IEnumerable<Location> GetAlarms()
        {
            return _alarmListProvider.GetAlarms().Select(alarm => new Location()
            {
                Name = alarm.Name
            }).ToList();
        }
    }
}
