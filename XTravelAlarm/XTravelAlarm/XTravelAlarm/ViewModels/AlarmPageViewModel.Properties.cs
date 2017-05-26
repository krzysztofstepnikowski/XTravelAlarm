using System.Collections.ObjectModel;
using XTravelAlarm.Models;

namespace XTravelAlarm.ViewModels
{
    partial class AlarmPageViewModel
    {
        private ObservableCollection<AlarmLocationViewModel> _alarms;


        public ObservableCollection<AlarmLocationViewModel> Alarms
        {
            get { return _alarms; }

            set { SetProperty(ref _alarms, value); }
        }

        private bool _isAlarmListPlaceholderVisible;

        public bool IsAlarmListPlaceholderVisible
        {
            get { return _isAlarmListPlaceholderVisible; }
            set { SetProperty(ref _isAlarmListPlaceholderVisible, value); }
        }

        private bool _isStopped;

        public bool IsStopped
        {
            get { return _isStopped; }
            set { SetProperty(ref _isStopped, value); }
        }
    }
}
