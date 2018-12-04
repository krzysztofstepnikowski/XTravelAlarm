using System;

namespace XTravelAlarm.Features.GPS
{
    public interface IGPSListener
    {
        void AddObserver(Guid alarmLocationId);
        void RemoveObserver(Guid alarmLocationId);
    }
}