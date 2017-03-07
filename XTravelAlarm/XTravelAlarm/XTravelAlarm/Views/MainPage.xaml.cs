using System;
using Xamarin.Forms;
using XTravelAlarm.ViewModels;

namespace XTravelAlarm.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
           
        }

        private async void GetLocalizationClicked(object sender, EventArgs e)
        {
            MyMap = (BindingContext as MainPageViewModel)?.Map;
            var retreiveLocation = (BindingContext as MainPageViewModel)?.RetreiveLocation();
            if (retreiveLocation != null)
                await retreiveLocation;
        }

       
    }
}
