using System.Collections.ObjectModel;
using System.Diagnostics;
using Acr.UserDialogs;
using Prism.Commands;
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

        private void GetAlarms()
        {
            var alarms = alarmPageFeatures.GetAll();
            Alarms = new ObservableCollection<AlarmLocationViewModel>(alarms);

            foreach (var alarm in alarms)
            {
                alarm.RunningStatusChanged = new DelegateCommand<bool?>(x => RunningStatusChanged(x, alarm));
            }
        }

        private void RunningStatusChanged(bool? isRunning, AlarmLocationViewModel alarm)
        {
            if (!isRunning.HasValue)
            {
                Debug.WriteLine("IsRunning is null");
                return;
            }

            if (isRunning.Value)
            {
                alarmPageFeatures.Enable(alarm.Id);
                UserDialogs.Instance.Toast("Alarm włączony");
            }

            else
            {
                alarmPageFeatures.Disable(alarm.Id);
                UserDialogs.Instance.Toast("Alarm wyłączony");
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
