using System;

namespace XTravelAlarm.Features.GPSobservation
{
    public interface IGPSListener
    {
        void AddObserver(Guid alarmLocationId);
        void RemoveObserver(Guid alarmLocationId);
    }
}