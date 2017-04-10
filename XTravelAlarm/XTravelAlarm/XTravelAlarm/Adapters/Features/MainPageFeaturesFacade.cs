using XTravelAlarm.Features;
using XTravelAlarm.Features.GPSobservation;
using XTravelAlarm.Services;
using XTravelAlarm.Views.Main;

namespace XTravelAlarm.Adapters.Features
{
    public class MainPageFeaturesFacade : IMainPageFeatures
    {
        private readonly InMemoryAlarmStorage alarmStorage;
        private readonly GPSListener gpsListener;

        public MainPageFeaturesFacade(GPSListener gpsListener, InMemoryAlarmStorage alarmStorage)
        {
            this.gpsListener = gpsListener;
            this.alarmStorage = alarmStorage;
        }

        public void Add(AlarmLocation alarmLocation)
        {
            gpsListener.AddObserver(alarmLocation.Id);
            alarmStorage.Add(alarmLocation);
        }
    }
}
