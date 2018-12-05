using System;
using System.Diagnostics;
using System.Linq;
using Acr.UserDialogs;
using Prism.Commands;
using Prism.Mvvm;
using Xamarin.Essentials;
using XTravelAlarm.Models;
using XTravelAlarm.Views.Main;

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

                try
                {
                    var location = (await Geocoding.GetLocationsAsync(Name)).FirstOrDefault();

                    if (location != null)
                    {
                        var newLocationAlarm = new AlarmLocation(Name, Distance,
                            location.Latitude, location.Longitude, true);

                        await mainPageFeatures.AddAlarmAsync(newLocationAlarm);
                        UserDialogs.Instance.Toast("Zapisano alarm.", TimeSpan.FromSeconds(3.0));
                        Debug.WriteLine(newLocationAlarm.ToString());
                    }

                    else
                    {
                        UserDialogs.Instance.Toast("Nie można zapisać alarmu. Sprawdź miejsce docelowe.", TimeSpan.FromSeconds(3.0));
                    }
                }
                catch (FeatureNotSupportedException fnsEx)
                {
                    Debug.WriteLine(fnsEx.Message);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }

            else
            {
                UserDialogs.Instance.Toast("Nie można zapisać alarmu.", TimeSpan.FromSeconds(3.0));
            }
        }
    }
}
