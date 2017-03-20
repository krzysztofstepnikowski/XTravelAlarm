﻿using System;
using System.Threading.Tasks;
using Acr.UserDialogs;
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
        private readonly IRinger ringerService;
        //private readonly IMainPageView mainPageView;

        public MainPageViewModel(IEventAggregator eventAggregator, IRinger ringerService)
        {
            this.eventAggregator = eventAggregator;
            this.ringerService = ringerService;

            GetLocationCommand = new DelegateCommand(async () => await GetLocationAsync());
            SaveAlarmCommand = new DelegateCommand(SaveAlarm);
            ringerService.Ring();
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


        public async Task GetLocationAsync()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 20;

            var position = await locator.GetPositionAsync(timeoutMilliseconds: 100000);
            //mainPageView.MoveMap(new Features.Position(position.Latitude, position.Longitude));
        }
    }
}
