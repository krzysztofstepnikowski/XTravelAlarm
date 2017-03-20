﻿using System.Collections.Generic;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Unity;
using Xamarin.Forms;
using XTravelAlarm.Adapters.Features;
using XTravelAlarm.Features;
using XTravelAlarm.Features.AlarmList;
using XTravelAlarm.Features.AlarmRinging;
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

            NavigationService.NavigateAsync("NavigationPage/MainTabbedPage");
        }

        protected override void RegisterTypes()
        {
            var alarmRepository = new HashSet<Location>();
           


            Container.RegisterTypeForNavigation<MainPage, MainPageViewModel>();
            Container.RegisterTypeForNavigation<AlarmsPage, AlarmPageViewModel>();
            Container.RegisterTypeForNavigation<MainTabbedPage>();
            Container.RegisterTypeForNavigation<NavigationPage>();
            Container.RegisterType<IRinger>();
//            Container.RegisterType<IAlarmPageFeatures, AlarmListProvider>(new InjectionConstructor(alarmRepository));

            var ringerService = DependencyService.Get<IRinger>();
            Container.RegisterInstance(ringerService);

            Container.RegisterInstance<IAlarmPageFeatures>(new AlarmListProvider(alarmRepository, ringerService));

            



//            Container.RegisterInstance<IMainPageFeatures>(new MainPageFeatureFacade(null));
        }

      
    }
}
