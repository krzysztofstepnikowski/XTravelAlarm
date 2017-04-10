using System;
using System.Collections.Generic;
using Plugin.Geolocator;
using XTravelAlarm.Features.AlarmRinging;

namespace XTravelAlarm.Features.GPSobservation
{
    public class GPSListener
    {
        private readonly HashSet<Guid> gpsObservers;
        private readonly AlarmCaller alarmCaller;


        public GPSListener(HashSet<Guid> gpsObservers,AlarmCaller alarmCaller)
        {
            this.gpsObservers = gpsObservers;
            this.alarmCaller = alarmCaller;
            CrossGeolocator.Current.PositionChanged += CurrentPositionChanged;
        }

        private void CurrentPositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
            foreach (var alarmId in gpsObservers)
            {
                alarmCaller.UpdatePosition(new Position(e.Position.Latitude,e.Position.Longitude),alarmId);
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
