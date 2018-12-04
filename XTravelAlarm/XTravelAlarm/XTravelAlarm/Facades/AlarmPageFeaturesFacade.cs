using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XTravelAlarm.Features.GPS;
using XTravelAlarm.Models.PO;
using XTravelAlarm.Services.Interfaces;
using XTravelAlarm.Views.Alarms;

namespace XTravelAlarm.Facades
{
    public class AlarmPageFeaturesFacade : IAlarmPageFeatures
    {
        private readonly IAlarmDatabaseService alarmDatabase;
        private readonly IGPSListener gpsListener;

        public AlarmPageFeaturesFacade(IGPSListener gpsListener, IAlarmDatabaseService alarmDatabase)
        {
            this.gpsListener = gpsListener;
            this.alarmDatabase = alarmDatabase;
        }

        public async Task<IEnumerable<AlarmLocationViewModel>> GetAllAsync()
        {
            var alarms = await alarmDatabase.GetAllAsync();
            return alarms.Select(x => new AlarmLocationViewModel()
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
            await alarmDatabase.UpdateAlarmAsync(alarm);
            gpsListener.AddObserver(alarmId);
        }


        public async void Disable(Guid alarmId)
        {
            var alarm = await alarmDatabase.GetAlarmAsync(alarmId);
            alarm.IsRunning = false;
            await alarmDatabase.UpdateAlarmAsync(alarm);
            gpsListener.RemoveObserver(alarmId);
        }


        public async Task RemoveAlarmAsync(Guid alarmId)
        {
            var alarm = await alarmDatabase.GetAlarmAsync(alarmId);

            if (alarm != null)
            {
                await alarmDatabase.RemoveAlarmAsync(alarm);
                gpsListener.RemoveObserver(alarmId);
            }
        }
    }
}
