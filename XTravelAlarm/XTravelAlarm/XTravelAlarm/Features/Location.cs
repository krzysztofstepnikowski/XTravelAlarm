namespace XTravelAlarm.Features
{
    public class Location
    {
        public string Name { get; set; }

        public Position Position { get; set; }

        public double Distance { get; set; }

        public Location(string name, Position position)
        {
            Name = name;
            Position = position;
        }

        public Location(string name, double distance)
        {
            Name = name;
            Distance = distance;
        }

        public Location()
        {
        }
    }
}
