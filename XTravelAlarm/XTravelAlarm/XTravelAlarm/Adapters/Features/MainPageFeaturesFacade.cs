using XTravelAlarm.Features;
using XTravelAlarm.Features.AlarmList;
using XTravelAlarm.Features.GPSobservation;
using XTravelAlarm.Views.Main;

namespace XTravelAlarm.Adapters.Features
{
    public class MainPageFeaturesFacade : IMainPageFeatures
    {
        private readonly AlarmListProvider alarmListProvider;
        private readonly GPSListener gpsListener;

        public MainPageFeaturesFacade(AlarmListProvider alarmListProvider, GPSListener gpsListener)
        {
            this.alarmListProvider = alarmListProvider;
            this.gpsListener = gpsListener;
        }

        public void Add(AlarmLocation alarmLocation)
        {
            gpsListener.AddObserver(alarmLocation.Id);
            alarmListProvider.Add(alarmLocation);
        }
    }
}
