using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
    }
}
