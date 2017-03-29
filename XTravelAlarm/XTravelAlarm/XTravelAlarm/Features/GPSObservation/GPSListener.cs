using System.Collections.Generic;

namespace XTravelAlarm.Features.GPSobservation
{
    public class GPSListener : IGPSListener
    {
        private readonly HashSet<AlarmLocation> gpsObservers;


        public GPSListener(HashSet<AlarmLocation> gpsObservers)
        {
            this.gpsObservers = gpsObservers;
        }

        public void AddObserver(AlarmLocation alarmLocation)
        {
            gpsObservers.Add(alarmLocation);
            alarmLocation.IsRunning = true;
        }

        public void RemoveObserver(AlarmLocation alarmLocation)
        {
            gpsObservers.Remove(alarmLocation);
            alarmLocation.IsRunning = false;
        }
    }
}
