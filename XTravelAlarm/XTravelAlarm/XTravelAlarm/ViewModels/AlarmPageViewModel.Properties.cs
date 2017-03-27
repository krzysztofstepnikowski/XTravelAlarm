using System.Collections.ObjectModel;
using XTravelAlarm.Features;

namespace XTravelAlarm.ViewModels
{
     partial class AlarmPageViewModel
    {
        private ObservableCollection<Location> _alarms;

        public ObservableCollection<Location> Alarms
        {
            get { return _alarms; }

            set { SetProperty(ref _alarms, value); }
        }
    }
}
