namespace XTravelAlarm.Features
{
    public class Location
    {
        public string Name { get; set; }

        public Position Position { get; set; }

        public double Distance { get; set; }


        public Location(string name, double distance, Position position)
        {
            Name = name;
            Distance = distance;
            Position = position;
        }

        public Location()
        {
        }
    }
}
