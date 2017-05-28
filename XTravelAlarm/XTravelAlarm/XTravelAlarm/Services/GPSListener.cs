using System;
using System.Collections.Generic;
using System.Diagnostics;
using Plugin.Geolocator;
using XTravelAlarm.Features;
using XTravelAlarm.Features.AlarmRinging;

namespace XTravelAlarm.Services
{
    public class GPSListener
    {
        private readonly HashSet<Guid> gpsObservers;
        private readonly AlarmCaller alarmCaller;


        public GPSListener(HashSet<Guid> gpsObservers, AlarmCaller alarmCaller)
        {
            this.gpsObservers = gpsObservers;
            this.alarmCaller = alarmCaller;
            CrossGeolocator.Current.PositionChanged += CurrentPositionChanged;
        }

        private async void CurrentPositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
            foreach (var alarmId in gpsObservers)
            {
                await alarmCaller.UpdatePosition(new Position(e.Position.Latitude, e.Position.Longitude), alarmId);
            }

            Debug.WriteLine($"Listener: {GetHashCode()}");
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
