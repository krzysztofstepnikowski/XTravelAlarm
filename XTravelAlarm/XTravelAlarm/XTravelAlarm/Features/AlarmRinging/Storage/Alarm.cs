using System;

namespace XTravelAlarm.Features.AlarmRinging
{
    public class Alarm
    {
        public Guid Id { get; }
        public Position Destination { get; }
        public double Distance { get; }
    }
}
