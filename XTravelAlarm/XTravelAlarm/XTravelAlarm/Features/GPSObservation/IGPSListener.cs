namespace XTravelAlarm.Features.GPSobservation
{
    public interface IGPSListener
    {
        void AddObserver(AlarmLocation alarmLocation);
        void RemoveObserver(AlarmLocation alarmLocation);
    }
}