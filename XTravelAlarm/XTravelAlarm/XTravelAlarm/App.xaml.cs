using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Practices.Unity;
using Plugin.Geolocator;
using Prism;
using Prism.Ioc;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XTravelAlarm.Facades;
using XTravelAlarm.Features.AlarmRinging;
using XTravelAlarm.Features.GPS;
using XTravelAlarm.Services;
using XTravelAlarm.Services.Interfaces;
using XTravelAlarm.ViewModels;
using XTravelAlarm.Views;
using XTravelAlarm.Views.Alarms;
using XTravelAlarm.Views.Main;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XTravelAlarm
{
    public partial class App
    {
        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<AlarmsPage, AlarmPageViewModel>();
            containerRegistry.RegisterForNavigation<MainTabbedPage>();
            containerRegistry.RegisterForNavigation<NavigationPage>();

            containerRegistry.Register<IAlarmCaller, AlarmCaller>();
            containerRegistry.Register<IAlarmDatabaseService, AlarmDatabaseService>();
            containerRegistry.Register<IHashSetCollection,HashSetCollection>();
            containerRegistry.Register<IGPSListener, GPSListener>();
            containerRegistry.Register<IMainPageFeatures, MainPageFeaturesFacade>();
            containerRegistry.Register<IAlarmPageFeatures, AlarmPageFeaturesFacade>();
        }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync("NavigationPage/MainTabbedPage/");
        }

        protected override async void OnStart()
        {
            base.OnStart();
            if (!CrossGeolocator.Current.IsListening)
            {
                await CrossGeolocator.Current.StartListeningAsync(new TimeSpan(1000), 100);
                Debug.WriteLine("OnStart");
            }
        }


        protected override async void OnResume()
        {
            base.OnResume();
            if (!CrossGeolocator.Current.IsListening)
            {
                await CrossGeolocator.Current.StartListeningAsync(new TimeSpan(1000), 100);
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
