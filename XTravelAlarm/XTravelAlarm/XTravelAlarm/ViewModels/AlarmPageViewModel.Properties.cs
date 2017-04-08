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
    }
}
