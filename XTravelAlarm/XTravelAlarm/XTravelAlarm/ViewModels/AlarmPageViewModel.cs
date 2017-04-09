using System.Collections.ObjectModel;
using Acr.UserDialogs;
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


            foreach (var alarm in alarms)
            {
                if (alarm.IsRunning)
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
            Alarms = new ObservableCollection<AlarmLocationViewModel>(alarms);
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
