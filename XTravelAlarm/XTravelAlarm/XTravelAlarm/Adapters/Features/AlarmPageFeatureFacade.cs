using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<Alarm> GetAlarms()
        {
            return _alarmListProvider.GetAlarms().Select(alarm => new Alarm()
            {
                Name = alarm.Name
            }).ToList();
        }
    }
}
