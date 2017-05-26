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
        private readonly AlarmDatabaseService alarmDatabase;
        private readonly GPSListener gpsListener;

        public AlarmPageFeaturesFacade(GPSListener gpsListener, AlarmDatabaseService alarmDatabase)
        {
            this.gpsListener = gpsListener;
            this.alarmDatabase = alarmDatabase;
        }

        public  IEnumerable<AlarmLocationViewModel> GetAll()
        {
            return alarmDatabase.GetAllAsync().Result.Select(x => new AlarmLocationViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Distance = x.Distance,
                IsRunning = x.IsRunning
            }).ToList();
        }

        public async void Enable(Guid alarmId)
        {
            var alarm = await alarmDatabase.GetAlarmAsync(alarmId);
            alarm.IsRunning = true;
            gpsListener.AddObserver(alarmId);
        }


        public async void Disable(Guid alarmId)
        {
            var alarm = await alarmDatabase.GetAlarmAsync(alarmId);
            alarm.IsRunning = false;
            gpsListener.RemoveObserver(alarmId);
        }

        public async void Remove(Guid alarmId)
        {
            await alarmDatabase.RemoveAlarmAsync(alarmId);
            gpsListener.RemoveObserver(alarmId);
        }
    }
}
