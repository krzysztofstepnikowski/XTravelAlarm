using System.Collections.Generic;
using System.Linq;
using Plugin.Geolocator;
using XTravelAlarm.Features.AlarmRinging;

namespace XTravelAlarm.Features.AlarmList
{
    public class AlarmListProvider
    {
        private readonly HashSet<AlarmLocation> alarms;
        private readonly IRinger ringer;

        public AlarmListProvider(HashSet<AlarmLocation> alarms, IRinger ringer)
        {
            this.alarms = alarms;
            this.ringer = ringer;
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
            var alarmCaller = new AlarmCaller(alarmLocation.Position, alarmLocation.Distance, ringer);
            CrossGeolocator.Current.PositionChanged += (s, e) => CurrentPositionChanged(e, alarmCaller);
        }

        private void CurrentPositionChanged(Plugin.Geolocator.Abstractions.PositionEventArgs e, AlarmCaller alarm)
        {
            var position = e.Position;

            alarm.UpdatePosition(new Position(position.Latitude, position.Longitude));
        }

       
    }
}
