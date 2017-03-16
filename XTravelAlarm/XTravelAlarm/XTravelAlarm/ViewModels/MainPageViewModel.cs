﻿using System.Diagnostics;
using System.Threading.Tasks;
using Plugin.Geolocator;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using XTravelAlarm.Events;
using XTravelAlarm.Features;

namespace XTravelAlarm.ViewModels
{
    public partial class MainPageViewModel : BindableBase
    {
        private readonly IEventAggregator eventAggregator;
        //private readonly IMainPageView mainPageView;

        public MainPageViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;

            GetLocationCommand = new DelegateCommand(async () => await GetLocationAsync());
            SaveAlarmCommand = new DelegateCommand(SaveAlarm);
        }

        private void SaveAlarm()
        {
            var newLocationAlarm = new Location(Name, Distance);

            if (!string.IsNullOrEmpty(Name) && Distance > 0)
            {
                eventAggregator.GetEvent<SaveAlarmEvent>().Publish(newLocationAlarm);
            }

            Debug.WriteLine("Nie mozna zapisac alarmu");

            
        }


        public async Task GetLocationAsync()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 20;

            var position = await locator.GetPositionAsync(timeoutMilliseconds: 100000);
            //mainPageView.MoveMap(new Features.Position(position.Latitude, position.Longitude));
        }
    }
}
