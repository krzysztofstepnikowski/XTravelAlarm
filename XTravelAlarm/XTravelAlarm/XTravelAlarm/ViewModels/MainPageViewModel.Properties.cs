using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;

namespace XTravelAlarm.ViewModels
{
    public partial class MainPageViewModel
    {
//        private string _latitude;
//
//        public string Latitude
//        {
//            get { return _latitude; }
//
//            set { SetProperty(ref _latitude, value); }
//        }
//
//        private string _longitude;
//
//        public string Longitude
//        {
//            get { return _longitude; }
//            set { SetProperty(ref _longitude, value); }
//        }

        private Map _map;

        public Map Map
        {
            get { return _map; }

            set { SetProperty(ref _map, value); }
        }
    }
}
