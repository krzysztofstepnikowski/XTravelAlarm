using System;
using System.Diagnostics;
using System.Linq;
using Acr.UserDialogs;
using Prism.Commands;
using Prism.Mvvm;
using Xamarin.Forms.Maps;
using XTravelAlarm.Features;
using XTravelAlarm.Views.Main;
using Position = XTravelAlarm.Features.Position;

namespace XTravelAlarm.ViewModels
{
    public partial class MainPageViewModel : BindableBase
    {
        private readonly IMainPageFeatures mainPageFeatures;

        public MainPageViewModel(IMainPageFeatures mainPageFeatures)
        {
            this.mainPageFeatures = mainPageFeatures;

            SaveAlarmCommand = new DelegateCommand(SaveAlarmAsync);
        }


        private async void SaveAlarmAsync()
        {
            if (!string.IsNullOrEmpty(Name) && Distance > 0)
            {
                var geocoder = new Geocoder();

                var targetPlace = (await geocoder.GetPositionsForAddressAsync(Name)).FirstOrDefault();


                if (targetPlace == default(Xamarin.Forms.Maps.Position))
                {
                    return;
                }


                var newLocationAlarm = new AlarmLocation(Name, Distance,
                    new Position(targetPlace.Latitude, targetPlace.Longitude), true);


                mainPageFeatures.Add(newLocationAlarm);
                UserDialogs.Instance.Toast("Zapisano alarm.", TimeSpan.FromSeconds(3.0));
                Debug.WriteLine(newLocationAlarm.Position.ToString());
            }

            else
            {
                UserDialogs.Instance.Toast("Nie można zapisać alarmu.", TimeSpan.FromSeconds(3.0));
            }
        }
    }
}
