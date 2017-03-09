using Microsoft.Practices.Unity;
using Prism.Unity;
using Xamarin.Forms;
using XTravelAlarm.Adapters.Features;
using XTravelAlarm.Features.AlarmList;
using XTravelAlarm.ViewModels;
using XTravelAlarm.Views;
using XTravelAlarm.Views.AlarmPage;
using XTravelAlarm.Views.Main;

namespace XTravelAlarm
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync("NavigationPage/MainTabbedPage");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<NavigationPage>();
            Container.RegisterTypeForNavigation<MainTabbedPage>();
            Container.RegisterTypeForNavigation<MainPage, MainPageViewModel>();
            Container.RegisterTypeForNavigation<MyAlarmsPage, AlarmPageViewModel>();
            Container.RegisterType<IAlarmPageFeatures, AlarmPageFeatureFacade>();

            Container.RegisterInstance<IAlarmPageFeatures>(new AlarmPageFeatureFacade(new AlarmListProvider()));


        }

      
    }
}
