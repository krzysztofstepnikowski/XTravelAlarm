using System.Collections.Generic;
using Plugin.Geolocator;
using XTravelAlarm.Features.AlarmRinging;

namespace XTravelAlarm.Features.GPSobservation
{
    public class GPSListener : IGPSListener
    {
        private readonly HashSet<AlarmLocation> gpsObservers;
        private readonly IRinger ringer;


        public GPSListener(HashSet<AlarmLocation> gpsObservers, IRinger ringer)
        {
            this.gpsObservers = gpsObservers;
            this.ringer = ringer;
            CrossGeolocator.Current.PositionChanged += CurrentPositionChanged;
        }

        private void CurrentPositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
            foreach (var item in gpsObservers)
            {
                var alarmCaller = new AlarmCaller(item.Position,item.Distance,ringer);
                alarmCaller.UpdatePosition(new Position(e.Position.Latitude,e.Position.Longitude));
            }
           
        }

        public void AddObserver(AlarmLocation alarmLocation)
        {
            gpsObservers.Add(alarmLocation);
           
        }

        public void RemoveObserver(AlarmLocation alarmLocation)
        {
            gpsObservers.Remove(alarmLocation);
        }


    }
}
