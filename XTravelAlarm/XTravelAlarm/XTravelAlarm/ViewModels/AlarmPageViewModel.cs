using System.Collections.ObjectModel;
using Prism.Mvvm;
using Prism.Navigation;
using XTravelAlarm.Features;
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

            var alarms = alarmPageFeatures.GetAll();
            Alarms = new ObservableCollection<AlarmLocation>(alarms);
        }


        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            Name = (string) parameters["name"];
            Distance = (double) parameters["distance"];
            IsRunning = (bool) parameters["isRunning"];

            alarmLocation = new AlarmLocation(Name, Distance, new Position(50.054067, 21.996808999999985), IsRunning);


            alarmPageFeatures.Add(alarmLocation);
            Alarms.Add(alarmLocation);
        }


        public void OnInternalNavigatedFrom(NavigationParameters navParams)
        {
        }

        public void OnInternalNavigatedTo(NavigationParameters navParams)
        {
        }
    }
}
