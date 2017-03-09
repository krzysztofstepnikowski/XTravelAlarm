using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XTravelAlarm.ViewModels;

namespace XTravelAlarm.Views.AlarmPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyAlarmsPage : ContentPage
    {
        public MyAlarmsPage()
        {
            InitializeComponent();
            AlarmsListView.ItemSelected += (sender, e) => AlarmsListView.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            (BindingContext as AlarmPageViewModel)?.OnResume();
        }
    }
}
