using System;
using Acr.UserDialogs;
using Prism.Commands;
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
                location.RunningStatusChanged = new DelegateCommand<bool?>(isRunning =>
                {
                    
                    if (!isRunning.HasValue)
                    {
                        return;
                    }

                    if (isRunning.Value)
                    {
                        alarmPageFeatures.Enable(location);
                        UserDialogs.Instance.Toast("Alarm włączony", TimeSpan.FromSeconds(3));
                    }

                    else
                    {
                        alarmPageFeatures.Disable(location);
                        UserDialogs.Instance.Toast("Alarm wyłączony", TimeSpan.FromSeconds(3));
                    }
                });
                alarmPageFeatures.Add(location); //dysk
                Alarms.Add(location);
            }, true);
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
