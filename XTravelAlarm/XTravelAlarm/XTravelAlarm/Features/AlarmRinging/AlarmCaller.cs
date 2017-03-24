using System;

namespace XTravelAlarm.Features.AlarmRinging
{
    public class AlarmCaller
    {
        private readonly Position alarmPosition;
        private readonly double alarmDistance;
        private readonly IRinger ringer;

        public AlarmCaller(Position alarmPosition, double alarmDistance, IRinger ringer)
        {
            this.alarmPosition = alarmPosition;
            this.alarmDistance = alarmDistance;
            this.ringer = ringer;
        }


        public double CalculateDistance(Position position, Position alarmPosition)
        {
            var currentLatitude = position.Latitude;
            var currentLongitude = position.Longitude;

            var alarmLatitude = alarmPosition.Latitude;
            var alarmLongitude = alarmPosition.Longitude;

            return
                Math.Sqrt(Math.Pow(alarmLatitude - currentLatitude, 2) +
                          Math.Pow(alarmLongitude - currentLongitude, 2));
        }

        public void UpdatePosition(Position position)
        {
            var currentDistance = CalculateDistance(position,alarmPosition);

            if (currentDistance <= alarmDistance)
            {
                ringer.Ring();
            }
        }
    }
}
