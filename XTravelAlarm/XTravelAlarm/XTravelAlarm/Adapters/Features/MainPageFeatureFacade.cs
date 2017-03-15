using XTravelAlarm.Features;
using XTravelAlarm.Features.AlarmRepository;
using XTravelAlarm.Features.AlarmRinging;
using XTravelAlarm.Views.Main;

namespace XTravelAlarm.Adapters.Features
{
    public class MainPageFeatureFacade : IMainPageFeatures
    {
        private readonly AlarmCaller alarmCaller;
        private readonly AlarmRepository alarmRepository;


        public MainPageFeatureFacade(AlarmCaller alarmCaller, AlarmRepository alarmRepository)
        {
            this.alarmCaller = alarmCaller;
            this.alarmRepository = alarmRepository;
        }

        public void AddAlarm(Location targetLocation)
        {
            alarmRepository.AddAlarm(targetLocation);
        }
    }
}
