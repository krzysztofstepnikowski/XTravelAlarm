using System.Collections.Generic;
using System.Linq;
using Plugin.Geolocator;
using XTravelAlarm.Features.AlarmRinging;
using XTravelAlarm.Features.GPSobservation;
using XTravelAlarm.Views.Alarms;

namespace XTravelAlarm.Features.AlarmList
{
    public class AlarmListProvider : IAlarmPageFeatures
    {
        private readonly HashSet<AlarmLocation> alarms;
        private readonly IRinger ringer;
        private readonly IGPSListener gpsListener;

        public AlarmListProvider(HashSet<AlarmLocation> alarms, IRinger ringer, IGPSListener gpsListener)
        {
            this.alarms = alarms;
            this.ringer = ringer;
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

            if (alarmLocation.IsRunning)
            {
                gpsListener.AddObserver(alarmLocation);
                var alarmCaller = new AlarmCaller(alarmLocation.Position, alarmLocation.Distance, ringer);
                CrossGeolocator.Current.PositionChanged += (s, e) => CurrentPositionChanged(e, alarmCaller);
            }

            else
            {
                gpsListener.RemoveObserver(alarmLocation);
                CrossGeolocator.Current.StopListeningAsync();
            }
        }

        private void CurrentPositionChanged(Plugin.Geolocator.Abstractions.PositionEventArgs e, AlarmCaller alarm)
        {
            var position = e.Position;

            alarm.UpdatePosition(new Position(position.Latitude, position.Longitude));
        }

      
    }
}
