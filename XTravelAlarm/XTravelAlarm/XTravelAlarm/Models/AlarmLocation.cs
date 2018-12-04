using System;
using SQLite;

namespace XTravelAlarm.Models
{
    public class AlarmLocation
    {
        [PrimaryKey]
        public Guid Id { get; set; }
    
        public string Name { get; set; }
       
        public double Latitude { get; set; }

        public double Longitude { get; set; }

      
        public double Distance { get; set; }

        
        public bool IsRunning { get; set; }


        public AlarmLocation(string name, int distance, double latitude, double longitude, bool isRunning) : this()
        {
            Name = name;
            Distance = distance;
            Latitude = latitude;
            Longitude = longitude;
            IsRunning = isRunning;
        }

        public AlarmLocation()
        {
            Id = Guid.NewGuid();
        }

        public override string ToString()
        {
            return $"Position= ({Latitude};{Longitude})";
        }

    }
}
