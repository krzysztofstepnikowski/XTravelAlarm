using XTravelAlarm.Features;
using XTravelAlarm.Features.AlarmList;
using XTravelAlarm.Views.Main;

namespace XTravelAlarm.Adapters.Features
{
    public class MainPageFeaturesFacade : IMainPageFeatures
    {
        private readonly AlarmListProvider alarmListProvider;

        public MainPageFeaturesFacade(AlarmListProvider alarmListProvider)
        {
            this.alarmListProvider = alarmListProvider;
        }

        public void Add(AlarmLocation alarmLocation)
        {
            alarmListProvider.Add(alarmLocation);
        }
    }
}
