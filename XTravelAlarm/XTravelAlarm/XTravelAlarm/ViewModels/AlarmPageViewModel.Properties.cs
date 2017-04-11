using System.Collections.ObjectModel;
using Microsoft.Practices.ObjectBuilder2;
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

        private bool _isVisibleAlarms;

        public bool IsVisibleAlarms
        {
            get { return _isVisibleAlarms; }
            set { SetProperty(ref _isVisibleAlarms, value); }

       
    }
}

}
