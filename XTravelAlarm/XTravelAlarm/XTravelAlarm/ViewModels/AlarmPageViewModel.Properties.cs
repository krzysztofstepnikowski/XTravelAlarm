using System.Collections.ObjectModel;
using XTravelAlarm.Features.AlarmList;

namespace XTravelAlarm.ViewModels
{
     partial class AlarmPageViewModel
    {
        private ObservableCollection<Alarm> _alarms;

        public ObservableCollection<Alarm> Alarms
        {
            get { return _alarms; }

            set { SetProperty(ref _alarms, value); }
        }
    }
}
