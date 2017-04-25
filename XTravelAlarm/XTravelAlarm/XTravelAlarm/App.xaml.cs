using System;
using System.Collections.Generic;
using Microsoft.Practices.Unity;
using Prism.Unity;
using Xamarin.Forms;
using XTravelAlarm.Adapters.Features;
using XTravelAlarm.Features;
using XTravelAlarm.Features.AlarmRinging;
using XTravelAlarm.Features.AlarmRinging.Storage;
using XTravelAlarm.Models;
using XTravelAlarm.Services;
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
            var alarmRepository = new HashSet<AlarmLocation>();
            var gpsObservers = new HashSet<Guid>();


            Container.RegisterTypeForNavigation<MainPage, MainPageViewModel>();
            Container.RegisterTypeForNavigation<AlarmsPage, AlarmPageViewModel>();
            Container.RegisterTypeForNavigation<MainTabbedPage>();
            Container.RegisterTypeForNavigation<NavigationPage>();

            Container.RegisterType<AlarmCaller>();
            Container.RegisterType<IAlarmStorage,InMemoryAlarmStorage>(new InjectionConstructor(alarmRepository));
            Container.RegisterType<GPSListener>(new InjectionConstructor(gpsObservers, new ResolvedParameter<AlarmCaller>()));

            Container.RegisterType<IMainPageFeatures, MainPageFeaturesFacade>();
            Container.RegisterType<IAlarmPageFeatures, AlarmPageFeaturesFacade>();
        }
    }
}
