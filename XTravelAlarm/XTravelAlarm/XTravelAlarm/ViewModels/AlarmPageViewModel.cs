using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Prism.Mvvm;
using Prism.Navigation;
using XTravelAlarm.Features.AlarmList;
using XTravelAlarm.Views.Alarms;
using XTravelAlarm.Utils;

namespace XTravelAlarm.ViewModels
{
    public partial class AlarmPageViewModel : BindableBase, INavigationAware, IMultiPageNavigationAware
    {
        private readonly IAlarmPageFeatures _alarmPageFeatures;

        public AlarmPageViewModel(IAlarmPageFeatures alarmPageFeatures)
        {
            _alarmPageFeatures = alarmPageFeatures;
            
        }

        public void OnResume()
        {
            try
            {
                var alarms = _alarmPageFeatures.GetAlarms();

                Alarms = new ObservableCollection<Alarm>(alarms);
            }
            catch (Exception ex)
            {
                
                Debug.WriteLine(ex.Message);
            }
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            OnResume();
        }

        public void OnInternalNavigatedFrom(NavigationParameters navParams)
        {
        }

        public void OnInternalNavigatedTo(NavigationParameters navParams)
        {
            OnResume();
        }
    }
}
