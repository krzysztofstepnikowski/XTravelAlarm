using System.Collections.ObjectModel;
using XTravelAlarm.Features;

namespace XTravelAlarm.ViewModels
{
     partial class AlarmPageViewModel
    {
        private ObservableCollection<AlarmLocation> _alarms;

        public ObservableCollection<AlarmLocation> Alarms
        {
            get { return _alarms; }

            set
            {
                SetProperty(ref _alarms, value); 
               
            }
        }

       
    }
}
