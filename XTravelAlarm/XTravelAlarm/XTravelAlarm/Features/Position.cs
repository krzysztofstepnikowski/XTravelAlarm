namespace XTravelAlarm.Features
{
    public class Position
    {
        public double Latitude { get; set; } = 50.025725;
        public double Longitude { get; set; } = 22.031078;

        public Position(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
