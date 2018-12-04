using System.Threading.Tasks;
using XTravelAlarm.Features.GPS;
using XTravelAlarm.Models;
using XTravelAlarm.Services.Interfaces;
using XTravelAlarm.Views.Main;

namespace XTravelAlarm.Facades
{
    public class MainPageFeaturesFacade : IMainPageFeatures
    {
        private readonly IAlarmDatabaseService alarmDatabase;
        private readonly IGPSListener gpsListener;

        public MainPageFeaturesFacade(IGPSListener gpsListener, IAlarmDatabaseService alarmDatabase)
        {
            this.gpsListener = gpsListener;
            this.alarmDatabase = alarmDatabase;
        }

        public async Task AddAlarmAsync(AlarmLocation alarmLocation)
        {
            gpsListener.AddObserver(alarmLocation.Id);
            await alarmDatabase.AddAlarmAsync(alarmLocation);
        }
    }
}
