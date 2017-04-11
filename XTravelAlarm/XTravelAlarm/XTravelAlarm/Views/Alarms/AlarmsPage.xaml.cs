using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XTravelAlarm.Models;
using XTravelAlarm.ViewModels;

namespace XTravelAlarm.Views.Alarms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AlarmsPage : ContentPage
    {
        public AlarmsPage()
        {
            InitializeComponent();
            AlarmsListView.ItemSelected += (sender, e) => AlarmsListView.SelectedItem = null;
        }

        private void DeleteClicked(object sender, EventArgs e)
        {
            (BindingContext as AlarmPageViewModel)?.RemoveAlarm.Execute(
               (sender as MenuItem)?.CommandParameter as AlarmLocationViewModel);
        }
    }
}
