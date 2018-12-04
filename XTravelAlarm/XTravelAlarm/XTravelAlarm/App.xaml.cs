using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Practices.Unity;
using Plugin.Geolocator;
using Prism.Unity;
using Xamarin.Forms;
using XTravelAlarm.Facades;
using XTravelAlarm.Features.AlarmRinging;
using XTravelAlarm.Features.GPS;
using XTravelAlarm.Services;
using XTravelAlarm.Services.Interfaces;
using XTravelAlarm.ViewModels;
using XTravelAlarm.Views;
using XTravelAlarm.Views.Alarms;
using XTravelAlarm.Views.Main;

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
            Container.RegisterTypeForNavigation<MainPage, MainPageViewModel>();
            Container.RegisterTypeForNavigation<AlarmsPage, AlarmPageViewModel>();
            Container.RegisterTypeForNavigation<MainTabbedPage>();
            Container.RegisterTypeForNavigation<NavigationPage>();

            Container.RegisterType<IAlarmCaller,AlarmCaller>();
            Container.RegisterType<IAlarmDatabaseService, AlarmDatabaseService>();
            Container.RegisterType<IGPSListener,GPSListener>(new ContainerControlledLifetimeManager(),new InjectionConstructor(new HashSet<Guid>(), new ResolvedParameter<IAlarmCaller>()));
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
