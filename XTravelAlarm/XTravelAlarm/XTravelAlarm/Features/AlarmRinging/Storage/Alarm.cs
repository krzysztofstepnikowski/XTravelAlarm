namespace XTravelAlarm.Features.AlarmRinging.Storage
{
    public class Alarm
    {
        public Position Destination { get; }
        public double Distance { get; }

        public Alarm(Position destination, double distance)
        {
            Destination = destination;
            Distance = distance;
        }
    }
}
