using System.Collections.Generic;
using System.Linq;
using XTravelAlarm.Features;
using XTravelAlarm.Features.AlarmList;
using XTravelAlarm.Models;
using XTravelAlarm.Views.Alarms;

namespace XTravelAlarm.Adapters.Features
{
    public class AlarmPageFeaturesFacade : IAlarmPageFeatures
    {
        private readonly AlarmListProvider alarmListProvider;

        public AlarmPageFeaturesFacade(AlarmListProvider alarmListProvider)
        {
            this.alarmListProvider = alarmListProvider;
        }

        public IEnumerable<AlarmLocationViewModel> GetAll()
        {
            return alarmListProvider.GetAll().Select(x => new AlarmLocationViewModel()
            {
                Name = x.Name,
                Distance = x.Distance,
                IsRunning = x.IsRunning
            }).ToList();
        }

        public void Add(AlarmLocation alarmLocation)
        {
            alarmListProvider.Add(alarmLocation);
        }
    }
}
