using System.Collections.Generic;
using System.Linq;
using XTravelAlarm.Views.Alarms;

namespace XTravelAlarm.Features.AlarmList
{
   public class AlarmListProvider : IAlarmPageFeatures
   {
        public IEnumerable<Alarm> GetAlarms()
        {
            return Enumerable.Range(0, 5)
                .Select(i => new Alarm()
                {
                    Name = "Alarm " + i
                }).ToList();
        }
    }
}
