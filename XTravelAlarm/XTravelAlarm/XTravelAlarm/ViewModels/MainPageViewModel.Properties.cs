using Xamarin.Forms.Maps;

namespace XTravelAlarm.ViewModels
{
    public partial class MainPageViewModel
    {
        private Map _map;

        public Map Map
        {
            get { return _map; }

            set { SetProperty(ref _map, value); }
        }

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public double Distance { get; set; }
    }
}
