using System.Collections.Generic;
using System.Linq;
using Plugin.Geolocator;
using XTravelAlarm.Features.AlarmRinging;
using XTravelAlarm.Views.Alarms;

namespace XTravelAlarm.Features.AlarmList
{
    public class AlarmListProvider : IAlarmPageFeatures
    {
        private readonly HashSet<Location> alarms;
        private readonly IRinger ringer;

        public AlarmListProvider(HashSet<Location> alarms, IRinger ringer)
        {
            this.alarms = alarms;
            this.ringer = ringer;
        }

        public IEnumerable<Location> GetAll()
        {
            return alarms.Select(x => new Location
            {
                Name = x.Name,
                Distance = x.Distance
            }).ToList();
        }

        public void Add(Location alarmLocation)
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
