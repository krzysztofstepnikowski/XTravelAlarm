using System.Threading.Tasks;
using Plugin.Geolocator;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using XTravelAlarm.Events;
using XTravelAlarm.Features;

namespace XTravelAlarm.ViewModels
{
    public partial class MainPageViewModel : BindableBase, INavigationAware
    {

        private readonly IEventAggregator eventAggregator;
        private readonly INavigationService navigationService;
        //private readonly IMainPageView mainPageView;

        public MainPageViewModel(IEventAggregator eventAggregator, INavigationService navigationService)
        {
            this.eventAggregator = eventAggregator;
            this.navigationService = navigationService;

            GetLocationCommand = new DelegateCommand(async () => await GetLocationAsync());
            SaveAlarmCommand = new DelegateCommand(SaveAlarm);

        }

        private void SaveAlarm()
        {
            var newLocationAlarm = new Location(Name);

            eventAggregator.GetEvent<SaveAlarmEvent>().Publish(newLocationAlarm);

            navigationService.NavigateAsync("AlarmsPage");

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
