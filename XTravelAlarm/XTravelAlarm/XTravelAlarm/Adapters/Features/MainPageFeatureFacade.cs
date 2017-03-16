using XTravelAlarm.Features.AlarmRinging;

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
