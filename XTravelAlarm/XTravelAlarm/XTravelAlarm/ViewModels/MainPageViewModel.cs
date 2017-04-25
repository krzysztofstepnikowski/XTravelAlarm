using System;
using System.Diagnostics;
using System.Linq;
using Acr.UserDialogs;
using Prism.Commands;
using Prism.Mvvm;
using Xamarin.Forms.Maps;
using XTravelAlarm.Features;
using XTravelAlarm.Services;
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

            AutoCompleteCommand = new DelegateCommand(GetPredictionsAsync);
            SaveAlarmCommand = new DelegateCommand(SaveAlarmAsync);
        }

        private async void GetPredictionsAsync()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                return;
            }

            var googleLocationAutoComplete = new GoogleLocationAutoComplete("AIzaSyCnsoE4LIw9R4Kd9vF_S3D2qJ7N_iyUFUc");

            try
            {
                var locations = await googleLocationAutoComplete.GetPredictionsAsync(Name);

                Debug.WriteLine($"Locations length= {locations.Length}");

                AutoCompletePredictions = locations.ToList();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
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
            }

            else
            {
                UserDialogs.Instance.Toast("Nie można zapisać alarmu.", TimeSpan.FromSeconds(3.0));
            }
        }
    }
}
