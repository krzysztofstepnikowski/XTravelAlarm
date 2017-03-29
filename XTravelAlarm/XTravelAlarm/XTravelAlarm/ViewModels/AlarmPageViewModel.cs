using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using XTravelAlarm.Events;
using XTravelAlarm.Views.Alarms;
using XTravelAlarm.Utils;

namespace XTravelAlarm.ViewModels
{
    public partial class AlarmPageViewModel : BindableBase, INavigationAware, IMultiPageNavigationAware
    {
        public AlarmPageViewModel(IEventAggregator eventAggregator, IAlarmPageFeatures alarmPageFeatures)
        {
            eventAggregator.GetEvent<SaveAlarmEvent>().Subscribe(location =>
            {
                alarmPageFeatures.Add(location);
                Alarms.Add(location);
            }, true);

            alarmPageFeatures.GetAll();
        }


        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
        }

        public void OnInternalNavigatedFrom(NavigationParameters navParams)
        {
        }

        public void OnInternalNavigatedTo(NavigationParameters navParams)
        {
        }
    }
}
