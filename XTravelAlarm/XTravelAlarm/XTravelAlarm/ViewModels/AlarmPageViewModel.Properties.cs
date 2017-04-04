using System.Collections.ObjectModel;
using XTravelAlarm.Features;

namespace XTravelAlarm.ViewModels
{
    partial class AlarmPageViewModel
    {
        private AlarmLocation alarmLocation;

        private string name;

        public string Name
        {
            get { return name; }

            set { SetProperty(ref name, value); }
        }

        private double distance;

        public double Distance
        {
            get { return distance; }

            set { SetProperty(ref distance, value); }
        }

        private bool isRunning;

        public bool IsRunning
        {
            get { return isRunning; }

            set { SetProperty(ref isRunning, value); }
        }

        private ObservableCollection<AlarmLocation> _alarms;
        

        public ObservableCollection<AlarmLocation> Alarms
        {
            get { return _alarms; }

            set { SetProperty(ref _alarms, value); }
        }
    }
}
