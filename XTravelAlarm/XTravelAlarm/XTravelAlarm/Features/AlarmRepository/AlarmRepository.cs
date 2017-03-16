using System.Collections.Generic;
using System.Linq;
using XTravelAlarm.Views.Alarms;

namespace XTravelAlarm.Features.AlarmRepository
{
   public class AlarmRepository : IAlarmPageFeatures
   {
       private readonly HashSet<Location> alarms;

       public AlarmRepository(HashSet<Location> alarms)
       {
           this.alarms = alarms;
       }

       public IEnumerable<Location> GetAll()
       {
           return alarms.Select(x => new Location
           {
               Name = x.Name
           }).ToList();
       }

       public void Add(Location alarmLocation)
       {
           alarms.Add(alarmLocation);
       }
   }
}
