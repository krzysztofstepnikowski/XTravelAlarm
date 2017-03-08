using System.Diagnostics;
using System.Threading.Tasks;
using Plugin.Geolocator;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.Forms.Maps;

namespace XTravelAlarm.ViewModels
{
    public partial class MainPageViewModel : BindableBase, INavigationAware
    {
        public MainPageViewModel()
        {
            Map = new Map();
            GetLocationCommand = new DelegateCommand(async () => await RetreiveLocation());
        }

        public async Task RetreiveLocation()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 20;

            var position = await locator.GetPositionAsync(timeoutMilliseconds: 100000);

            Latitude = $"{position.Latitude}";
            Longitude = $"{position.Longitude}";

            Map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(position.Latitude, position.Longitude),
                Distance.FromMeters(1)));
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
        }
    }
}
