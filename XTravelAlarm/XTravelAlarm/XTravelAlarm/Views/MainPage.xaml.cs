using System;
using System.Threading.Tasks;
using Plugin.Geolocator;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

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
            await RetreiveLocation();
        }

        public async Task RetreiveLocation()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 20;

            var position = await locator.GetPositionAsync(timeoutMilliseconds: 100000);

            LatitudeLabel.Text = $"Latitude: {position.Latitude}";
            LongitudeLabel.Text= $"Longitude: {position.Longitude}";

          MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(position.Latitude,position.Longitude),
                                                           Distance.FromMeters(1)));

           

        }
    }
}
