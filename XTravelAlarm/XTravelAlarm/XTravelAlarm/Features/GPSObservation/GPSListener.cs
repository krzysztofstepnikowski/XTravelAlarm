using System;
using System.Collections.Generic;
using Plugin.Geolocator;
using XTravelAlarm.Features.AlarmRinging;

namespace XTravelAlarm.Features.GPSobservation
{
    public class GPSListener : IGPSListener
    {
        private readonly HashSet<Guid> gpsObservers;
        private readonly IRinger ringer;


        public GPSListener(HashSet<Guid> gpsObservers, IRinger ringer)
        {
            this.gpsObservers = gpsObservers;
            this.ringer = ringer;
            CrossGeolocator.Current.PositionChanged += CurrentPositionChanged;
        }

        private void CurrentPositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
            foreach (var item in gpsObservers)
            {
                var alarmCaller = new AlarmCaller(ringer);
                alarmCaller.UpdatePosition(new Position(e.Position.Latitude,e.Position.Longitude));
            }
           
        }

        public void AddObserver(Guid alarmLocationId)
        {
            gpsObservers.Add(alarmLocationId);
           
        }

        public void RemoveObserver(Guid alarmLocationId)
        {
            gpsObservers.Remove(alarmLocationId);
        }


    }
}
