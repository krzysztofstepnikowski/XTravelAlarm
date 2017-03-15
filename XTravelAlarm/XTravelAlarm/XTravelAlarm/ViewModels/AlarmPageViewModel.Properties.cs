using System.Collections.ObjectModel;
using XTravelAlarm.Features;
using XTravelAlarm.Features.AlarmList;

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
