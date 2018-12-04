using System;
using System.Threading.Tasks;
using XTravelAlarm.Models;
using XTravelAlarm.PlatformServices;
using XTravelAlarm.Services.Interfaces;

namespace XTravelAlarm.Features.AlarmRinging
{
    public class AlarmCaller : IAlarmCaller
    {
        private readonly IRinger ringer;
        private readonly INotificationService notificationService;
        private readonly IAlarmDatabaseService alarmDatabase;

        public AlarmCaller(IRinger ringer, IAlarmDatabaseService alarmDatabase, INotificationService notificationService)
        {
            this.ringer = ringer;
            this.alarmDatabase = alarmDatabase;
            this.notificationService = notificationService;
        }


        private double CalculateDistance(Position position, AlarmLocation alarmLocation)
        {
            return CalculateWithHaversine(position, alarmLocation);
        }

        private double CalculateWithHaversine(Position position, AlarmLocation alarmLocation)
        {
            var R = 6371d;
            var currentLatitude = position.Latitude;
            var currentLongitude = position.Longitude;


            var alarmLatitude = alarmLocation.Latitude;
            var alarmLongitude = alarmLocation.Longitude;

            var differenceLatitudes = ToRadius(alarmLatitude - currentLatitude);
            var differenceLongitudes = ToRadius(alarmLongitude - currentLongitude);

            var a = Math.Sin(differenceLatitudes / 2d) * Math.Sin(differenceLatitudes / 2d) +
                    Math.Cos(ToRadius(currentLatitude)) * Math.Cos(ToRadius(alarmLatitude)) *
                    Math.Sin(differenceLongitudes / 2d) * Math.Sin(differenceLongitudes / 2d);

            var c = 2d * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1d - a));


            return R * c;
        }

        private double ToRadius(double deg)
        {
            return deg * (Math.PI / 180d);
        }


        public async Task UpdatePosition(Position position, Guid alarmId)
        {
            var alarm = await alarmDatabase.GetAlarmAsync(alarmId);


            var currentDistance = CalculateDistance(position, alarm);
            if (currentDistance <= alarm.Distance)
            {
                notificationService.Show("Alarm", "Wyłącz alarm", alarmId);
                ringer.PlaySound();
            }
        }
    }
}
