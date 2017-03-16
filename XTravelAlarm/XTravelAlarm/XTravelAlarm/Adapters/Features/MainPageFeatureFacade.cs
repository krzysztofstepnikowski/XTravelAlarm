using XTravelAlarm.Features;
using XTravelAlarm.Features.AlarmRepository;
using XTravelAlarm.Features.AlarmRinging;
using XTravelAlarm.Views.Main;

namespace XTravelAlarm.Adapters.Features
{
    public class MainPageFeatureFacade 
    {
        private readonly AlarmCaller alarmCaller;


        public MainPageFeatureFacade(AlarmCaller alarmCaller)
        {
            this.alarmCaller = alarmCaller;
        }

       
    }
}
