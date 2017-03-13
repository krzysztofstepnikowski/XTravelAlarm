using XTravelAlarm.Features;
using XTravelAlarm.Features.AlarmRinging;
using XTravelAlarm.Views.Main;

namespace XTravelAlarm.Adapters.Features
{
    public class MainPageFeatureFacade : IMainPageFeatures
    {
        private readonly AlarmCaller alarmCaller;

        public MainPageFeatureFacade(AlarmCaller alarmCaller)
        {
            this.alarmCaller = alarmCaller;
        }

        public void SaveAlarm(Position targetPosition, double Distance)
        {
            //Sprawdzanie alarmu
            var targetLatitude = targetPosition.Latitude;
            var targetLongitude = targetPosition.Longitude;

            targetPosition = new Position(targetLatitude,targetLongitude);
        }


    }
}
