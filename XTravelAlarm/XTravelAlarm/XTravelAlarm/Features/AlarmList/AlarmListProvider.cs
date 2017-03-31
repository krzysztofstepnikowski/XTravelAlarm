using System.Collections.Generic;
using System.Linq;
using XTravelAlarm.Features.GPSobservation;
using XTravelAlarm.Views.Alarms;

namespace XTravelAlarm.Features.AlarmList
{
    public class AlarmListProvider : IAlarmPageFeatures
    {
        private readonly HashSet<AlarmLocation> alarms;
        private readonly IGPSListener gpsListener;

        public AlarmListProvider(HashSet<AlarmLocation> alarms,IGPSListener gpsListener)
        {
            this.alarms = alarms;
            this.gpsListener = gpsListener;
        }

        public IEnumerable<AlarmLocation> GetAll()
        {
            return alarms.Select(x => new AlarmLocation
            {
                Name = x.Name,
                Distance = x.Distance,
                IsRunning = x.IsRunning
            }).ToList();
        }

        public void Add(AlarmLocation alarmLocation)
        {
            alarms.Add(alarmLocation);


            Enable(alarmLocation);
        }


        public void Enable(AlarmLocation alarmLocation)
        {
            gpsListener.AddObserver(alarmLocation);
        }

        public void Disable(AlarmLocation alarmLocation)
        {
            gpsListener.RemoveObserver(alarmLocation);
        }
    }
}
