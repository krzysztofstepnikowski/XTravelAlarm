using System.Threading.Tasks;
using Plugin.Geolocator;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using XTravelAlarm.Features;
using XTravelAlarm.Views.Main;

namespace XTravelAlarm.ViewModels
{
    public partial class MainPageViewModel : BindableBase, INavigationAware
    {
        private readonly IMainPageFeatures mainPageFeatures;
        //private readonly IMainPageView mainPageView;

        public MainPageViewModel(IMainPageFeatures mainPageFeatures)
        {
            this.mainPageFeatures = mainPageFeatures;
            //this.mainPageView = mainPageView;
            GetLocationCommand = new DelegateCommand(async () => await GetLocationAsync());
            SaveAlarmCommand = new DelegateCommand(SaveAlarm);
        }

        private void SaveAlarm()
        {
            var targetPosition = new Location(Name);
            //var distance = Distance;

            mainPageFeatures.AddAlarm(targetPosition);
        }


        public async Task GetLocationAsync()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 20;

            var position = await locator.GetPositionAsync(timeoutMilliseconds: 100000);
            //mainPageView.MoveMap(new Features.Position(position.Latitude, position.Longitude));
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
        }
    }
}
