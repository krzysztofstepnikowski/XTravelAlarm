using System;
using Acr.UserDialogs;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using XTravelAlarm.Features;

namespace XTravelAlarm.ViewModels
{
    public partial class MainPageViewModel : BindableBase
    {
        private readonly INavigationService navigationService;

        public MainPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;

            SaveAlarmCommand = new DelegateCommand(SaveAlarm);
        }

        private void SaveAlarm()
        {
            var newLocationAlarm = new AlarmLocation(Name, Distance, new Position(50.054067, 21.996808999999985),true);

            if (!string.IsNullOrEmpty(Name) && Distance > 0)
            {
                var navParams = new NavigationParameters();
                navParams.Add("name",newLocationAlarm.Name);
                navParams.Add("distance",newLocationAlarm.Distance);
                navParams.Add("isRunning",newLocationAlarm.IsRunning);
                UserDialogs.Instance.Toast("Zapisano alarm.", TimeSpan.FromSeconds(3.0));

                navigationService.NavigateAsync("AlarmsPage", navParams);
            }

            else
            {
                UserDialogs.Instance.Toast("Nie można zapisać alarmu.", TimeSpan.FromSeconds(3.0));
            }
        }
    }
}
