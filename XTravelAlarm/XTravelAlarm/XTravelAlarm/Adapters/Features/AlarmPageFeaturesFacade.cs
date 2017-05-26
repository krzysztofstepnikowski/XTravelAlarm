using System;
using System.Collections.Generic;
using System.Linq;
using XTravelAlarm.Models;
using XTravelAlarm.Services;
using XTravelAlarm.Views.Alarms;

namespace XTravelAlarm.Adapters.Features
{
    public class AlarmPageFeaturesFacade : IAlarmPageFeatures
    {
        private readonly InMemoryAlarmStorage alarmStorage;
        private readonly GPSListener gpsListener;

        public AlarmPageFeaturesFacade(GPSListener gpsListener, InMemoryAlarmStorage alarmStorage)
        {
            this.gpsListener = gpsListener;
            this.alarmStorage = alarmStorage;
        }

        public IEnumerable<AlarmLocationViewModel> GetAll()
        {
            return alarmStorage.GetAll().Select(x => new AlarmLocationViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Distance = x.Distance,
                IsRunning = x.IsRunning
            }).ToList();
        }

        public void Enable(Guid alarmId)
        {
            var alarm = alarmStorage.GetById(alarmId);
            alarm.IsRunning = true;
            gpsListener.AddObserver(alarmId);
        }


        public void Disable(Guid alarmId)
        {
            var alarm = alarmStorage.GetById(alarmId);
            alarm.IsRunning = false;
            gpsListener.RemoveObserver(alarmId);
        }

        public void Remove(Guid alarmId)
        {
            alarmStorage.Remove(alarmId);
            gpsListener.RemoveObserver(alarmId);
        }
    }
}
