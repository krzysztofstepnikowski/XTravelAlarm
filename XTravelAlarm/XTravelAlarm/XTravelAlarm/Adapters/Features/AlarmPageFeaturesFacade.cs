using System;
using System.Collections.Generic;
using System.Linq;
using XTravelAlarm.Features.AlarmList;
using XTravelAlarm.Features.GPSobservation;
using XTravelAlarm.Models;
using XTravelAlarm.Views.Alarms;

namespace XTravelAlarm.Adapters.Features
{
    public class AlarmPageFeaturesFacade : IAlarmPageFeatures
    {
        private readonly AlarmListProvider alarmListProvider;
        private readonly GPSListener gpsListener;

        public AlarmPageFeaturesFacade(AlarmListProvider alarmListProvider, GPSListener gpsListener)
        {
            this.alarmListProvider = alarmListProvider;
            this.gpsListener = gpsListener;
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

        public void Enable(Guid alarmId)
        {
            var alarm = alarmListProvider.GetById(alarmId);
            gpsListener.AddObserver(alarm.Id);
        }


        public void Disable(Guid alarmId)
        {
            var alarm = alarmListProvider.GetById(alarmId);
            gpsListener.RemoveObserver(alarm.Id);
        }

        
    }
}
