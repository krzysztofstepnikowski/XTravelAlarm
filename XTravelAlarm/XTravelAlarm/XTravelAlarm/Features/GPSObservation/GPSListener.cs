using System.Collections.Generic;

namespace XTravelAlarm.Features.GPSobservation
{
    public class GPSListener
    {
        private readonly HashSet<AlarmLocation> gpsObservers;


        public GPSListener(HashSet<AlarmLocation> gpsObservers)
        {
            this.gpsObservers = gpsObservers;
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
