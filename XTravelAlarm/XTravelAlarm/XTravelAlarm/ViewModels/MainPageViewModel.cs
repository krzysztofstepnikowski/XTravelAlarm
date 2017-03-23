using System;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Plugin.Geolocator;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using XTravelAlarm.Events;
using XTravelAlarm.Features;
using Position = Plugin.Geolocator.Abstractions.Position;

namespace XTravelAlarm.ViewModels
{
    public partial class MainPageViewModel : BindableBase
    {
        private readonly IEventAggregator eventAggregator;
        private readonly IRinger ringerService;
        //private readonly IMainPageView mainPageView;

        public MainPageViewModel(IEventAggregator eventAggregator, IRinger ringerService)
        {
            this.eventAggregator = eventAggregator;
            this.ringerService = ringerService;

            SaveAlarmCommand = new DelegateCommand(SaveAlarm);
        }

        private void SaveAlarm()
        {
            var newLocationAlarm = new Location(Name, Distance);

            if (!string.IsNullOrEmpty(Name) && Distance > 0)
            {
                eventAggregator.GetEvent<SaveAlarmEvent>().Publish(newLocationAlarm);
                UserDialogs.Instance.Toast("Zapisano alarm.", TimeSpan.MinValue);
            }

            else
            {
                UserDialogs.Instance.Toast("Nie można zapisać alarmu.", TimeSpan.MinValue);
            }
        }


        public async Task<Position> GetLocation()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 20;


            return await locator.GetPositionAsync(timeoutMilliseconds: 10000);

            //mainPageView.MoveMap(new Features.Position(position.Latitude, position.Longitude));
        }
    }
}
