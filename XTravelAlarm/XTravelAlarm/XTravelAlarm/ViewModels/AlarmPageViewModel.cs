using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using XTravelAlarm.Events;
using XTravelAlarm.Features;
using XTravelAlarm.Views.Alarms;
using XTravelAlarm.Utils;

namespace XTravelAlarm.ViewModels
{
    public partial class AlarmPageViewModel : BindableBase, INavigationAware, IMultiPageNavigationAware
    {
        private readonly IAlarmPageFeatures alarmPageFeatures;


        public AlarmPageViewModel(IEventAggregator eventAggregator, IAlarmPageFeatures alarmPageFeatures)
        {
            this.alarmPageFeatures = alarmPageFeatures;
            eventAggregator.GetEvent<SaveAlarmEvent>().Subscribe(obj =>
            {
                alarmPageFeatures.Add(obj);
                GetAlarms();
            },true);
        }

        public void GetAlarms()
        {
            try
            {
                var alarms = alarmPageFeatures.GetAll();

                Alarms = new ObservableCollection<Location>(alarms);
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
            GetAlarms();
        }

        public void OnInternalNavigatedFrom(NavigationParameters navParams)
        {
        }

        public void OnInternalNavigatedTo(NavigationParameters navParams)
        {
            GetAlarms();
        }
    }
}
