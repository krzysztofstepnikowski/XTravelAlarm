using System.Collections.ObjectModel;
using Prism.Mvvm;
using Prism.Navigation;
using XTravelAlarm.Models;
using XTravelAlarm.Views.Alarms;
using XTravelAlarm.Utils;

namespace XTravelAlarm.ViewModels
{
    public partial class AlarmPageViewModel : BindableBase, INavigationAware, IMultiPageNavigationAware
    {
        private readonly IAlarmPageFeatures alarmPageFeatures;

        public AlarmPageViewModel(IAlarmPageFeatures alarmPageFeatures)
        {
            this.alarmPageFeatures = alarmPageFeatures;
        }


        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            var alarms = alarmPageFeatures.GetAll();
            Alarms = new ObservableCollection<AlarmLocationViewModel>(alarms);
        }


        public void OnInternalNavigatedFrom(NavigationParameters navParams)
        {
        }

        public void OnInternalNavigatedTo(NavigationParameters navParams)
        {
        }
    }
}
