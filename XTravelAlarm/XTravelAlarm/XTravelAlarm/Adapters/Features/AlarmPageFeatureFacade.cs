using System.Collections.Generic;
using System.Linq;
using XTravelAlarm.Features;
using XTravelAlarm.Features.AlarmList;
using XTravelAlarm.Features.AlarmRunning;
using XTravelAlarm.Views.Alarms;

namespace XTravelAlarm.Adapters.Features
{
    public class AlarmPageFeatureFacade : IAlarmPageFeatures
    {
        private readonly AlarmListProvider alarmListProvider;
        private readonly AlarmRunningManager alarmRunningManager;

        public AlarmPageFeatureFacade(AlarmListProvider alarmListProvider, AlarmRunningManager alarmRunningManager)
        {
            this.alarmListProvider = alarmListProvider;
            this.alarmRunningManager = alarmRunningManager;
        }

        public IEnumerable<AlarmLocation> GetAll()
        {
            return alarmListProvider.GetAll().Select(alarmLocation => new AlarmLocation()
            {
                Name = alarmLocation.Name,
                Distance = alarmLocation.Distance,
                IsRunning = alarmLocation.IsRunning
            });
        }

        public void Add(AlarmLocation alarmLocation)
        {
            alarmListProvider.Add(alarmLocation);
        }

        public void SetAsAlarmRunning(AlarmLocation alarmLocation)
        {
           alarmRunningManager.SetAsAlarmRunning(alarmLocation);
        }

        public void RemoveFromAlarmsRunning(AlarmLocation alarmLocation)
        {
           alarmRunningManager.RemoveFromAlarmsRunning(alarmLocation);
        }
    }
}
