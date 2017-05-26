using XTravelAlarm.Features;
using XTravelAlarm.Services;
using XTravelAlarm.Views.Main;

namespace XTravelAlarm.Adapters.Features
{
    public class MainPageFeaturesFacade : IMainPageFeatures
    {
        private readonly AlarmDatabaseService alarmDatabase;
        private readonly GPSListener gpsListener;

        public MainPageFeaturesFacade(GPSListener gpsListener, AlarmDatabaseService alarmDatabase)
        {
            this.gpsListener = gpsListener;
            this.alarmDatabase = alarmDatabase;
        }

        public async void Add(AlarmLocation alarmLocation)
        {
            gpsListener.AddObserver(alarmLocation.Id);
            await alarmDatabase.AddAlarmAsync(alarmLocation);
        }
    }
}
