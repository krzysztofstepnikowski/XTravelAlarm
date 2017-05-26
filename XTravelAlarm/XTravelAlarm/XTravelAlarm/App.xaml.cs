﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Practices.Unity;
using Plugin.Geolocator;
using Prism.Unity;
using Xamarin.Forms;
using XTravelAlarm.Adapters.Features;
using XTravelAlarm.Features.AlarmRinging;
using XTravelAlarm.Features.AlarmRinging.Storage;
using XTravelAlarm.Services;
using XTravelAlarm.ViewModels;
using XTravelAlarm.Views;
using XTravelAlarm.Views.Alarms;
using XTravelAlarm.Views.Main;
using XTravelAlarm.Features;

namespace XTravelAlarm
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer)
        {
        }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync("NavigationPage/MainTabbedPage/");
        }

        protected override void RegisterTypes()
        {

            var gpsObservers = new HashSet<Guid>();
            var database = DependencyService.Get<ILocalFileHelper>();
            database.Connection.CreateTableAsync<AlarmLocation>();


            Container.RegisterTypeForNavigation<MainPage, MainPageViewModel>();
            Container.RegisterTypeForNavigation<AlarmsPage, AlarmPageViewModel>();
            Container.RegisterTypeForNavigation<MainTabbedPage>();
            Container.RegisterTypeForNavigation<NavigationPage>();

            Container.RegisterType<AlarmCaller>();
            Container.RegisterType<IAlarmDatabaseService, AlarmDatabaseService>(new InjectionConstructor(database.Connection));
            Container.RegisterType<GPSListener>(new ContainerControlledLifetimeManager(),new InjectionConstructor(gpsObservers,
                new ResolvedParameter<AlarmCaller>()));

            Container.RegisterType<IMainPageFeatures, MainPageFeaturesFacade>();
            Container.RegisterType<IAlarmPageFeatures, AlarmPageFeaturesFacade>();

           
        }

        protected override async void OnStart()
        {
            base.OnStart();
            if (!CrossGeolocator.Current.IsListening)
            {
                await CrossGeolocator.Current.StartListeningAsync(minTime: 1000, minDistance: 100);
                Debug.WriteLine("OnStart");
            }
        }


        protected override async void OnResume()
        {
            base.OnResume();
            if (!CrossGeolocator.Current.IsListening)
            {
                await CrossGeolocator.Current.StartListeningAsync(minTime: 1000, minDistance: 100);
                Debug.WriteLine("OnResume");
            }
        }

        protected override async void OnSleep()
        {
            base.OnSleep();
            if (CrossGeolocator.Current.IsListening)
            {
                await CrossGeolocator.Current.StopListeningAsync();
                Debug.WriteLine("OnSleep");
            }
        }
    }
}
