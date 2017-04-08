using System;
using Acr.UserDialogs;
using Prism.Commands;
using Prism.Mvvm;
using XTravelAlarm.Features;
using XTravelAlarm.Views.Main;

namespace XTravelAlarm.ViewModels
{
    public partial class MainPageViewModel : BindableBase
    {
        private readonly IMainPageFeatures mainPageFeatures;

        public MainPageViewModel(IMainPageFeatures mainPageFeatures)
        {
            this.mainPageFeatures = mainPageFeatures;

            SaveAlarmCommand = new DelegateCommand(SaveAlarm);
        }

        private void SaveAlarm()
        {
            var newLocationAlarm = new AlarmLocation(Name, Distance, new Position(50.054067, 21.996808999999985),true);

            if (!string.IsNullOrEmpty(Name) && Distance > 0)
            {
                mainPageFeatures.Add(newLocationAlarm);
                UserDialogs.Instance.Toast("Zapisano alarm.", TimeSpan.FromSeconds(3.0));
            }

            else
            {
                UserDialogs.Instance.Toast("Nie można zapisać alarmu.", TimeSpan.FromSeconds(3.0));
            }
        }
    }
}
