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

        private string _name;

        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        private int _distance;

        public int Distance
        {
            get { return _distance; }
            set { SetProperty(ref _distance, value); }
        }
    }
}
