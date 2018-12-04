using System;
using System.Collections.Generic;
using System.Diagnostics;
using Plugin.Geolocator;
using XTravelAlarm.Features.AlarmRinging;
using XTravelAlarm.Models;

namespace XTravelAlarm.Features.GPS
{
    public class GPSListener : IGPSListener
    {
        private readonly HashSet<Guid> gpsObservers;
        private readonly IAlarmCaller alarmCaller;

        public GPSListener(HashSet<Guid> gpsObservers, IAlarmCaller alarmCaller)
        {
            this.gpsObservers = gpsObservers;
            this.alarmCaller = alarmCaller;
            CrossGeolocator.Current.PositionChanged += CurrentPositionChanged;
        }
        
        public void AddObserver(Guid alarmLocationId)
        {
            gpsObservers.Add(alarmLocationId);
        }

        public void RemoveObserver(Guid alarmLocationId)
        {
            gpsObservers.Remove(alarmLocationId);
        }

        private async void CurrentPositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
            foreach (var alarmId in gpsObservers)
            {
                await alarmCaller.UpdatePosition(new Position(e.Position.Latitude, e.Position.Longitude), alarmId);
            }

            Debug.WriteLine($"Listener: {GetHashCode()}");
        }
    }
}
