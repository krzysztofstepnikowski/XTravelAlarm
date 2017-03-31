using System.Collections.Generic;
using Microsoft.Practices.Unity;
using Prism.Unity;
using Xamarin.Forms;
using XTravelAlarm.Features;
using XTravelAlarm.Features.AlarmList;
using XTravelAlarm.Features.GPSobservation;
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
            var alarmRepository = new HashSet<AlarmLocation>();


            Container.RegisterTypeForNavigation<MainPage, MainPageViewModel>();
            Container.RegisterTypeForNavigation<AlarmsPage, AlarmPageViewModel>();
            Container.RegisterTypeForNavigation<MainTabbedPage>();
            Container.RegisterTypeForNavigation<NavigationPage>();


            Container.RegisterType<IGPSListener, GPSListener>(new InjectionConstructor(alarmRepository,
                new ResolvedParameter<IRinger>()));
            Container.RegisterType<IAlarmPageFeatures, AlarmListProvider>(new InjectionConstructor(alarmRepository,
                new ResolvedParameter<IGPSListener>()));
        }
    }
}
