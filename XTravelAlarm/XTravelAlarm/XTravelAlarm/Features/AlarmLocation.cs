namespace XTravelAlarm.Features
{
    public class AlarmLocation
    {
        public string Name { get; set; }

        public Position Position { get; set; }

        public double Distance { get; set; }

        public bool IsRunning { get; set; }


        public AlarmLocation(string name, double distance, Position position, bool isRunning=true)
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
