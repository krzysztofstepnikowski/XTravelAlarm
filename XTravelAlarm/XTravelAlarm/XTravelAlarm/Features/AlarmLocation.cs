using Prism.Mvvm;

namespace XTravelAlarm.Features
{
    public class AlarmLocation : BindableBase
    {
        public string Name { get; set; }

        public Position Position { get; set; }

        public double Distance { get; set; }

        private bool _isRunning;

        public bool IsRunning
        {
            get { return _isRunning; }
            set
            {
                SetProperty(ref _isRunning, value);
            }
        }


        public AlarmLocation(string name, double distance, Position position, bool isRunning)
        {
            Name = name;
            Distance = distance;
            Position = position;
            IsRunning = isRunning;
        }

        public AlarmLocation()
        {
        }
    }
}
