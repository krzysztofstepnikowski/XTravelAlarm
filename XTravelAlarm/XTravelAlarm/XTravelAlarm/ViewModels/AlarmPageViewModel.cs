using System.Diagnostics;
using Plugin.Geolocator;
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

        private void CheckIsAlarmRunning()
        {
            foreach (var location in Alarms)
            {
                if (location.IsRunning)
                {
                    CrossGeolocator.Current.StartListeningAsync(minTime: 1000, minDistance: 1000);
                    Debug.WriteLine("GPS is running");
                }

                else
                {
                    CrossGeolocator.Current.StopListeningAsync();
                    Debug.WriteLine("GPS is stopped");
                }
            }
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
