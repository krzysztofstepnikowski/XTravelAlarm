using System.Collections.Generic;
using XTravelAlarm.Views.Main;

namespace XTravelAlarm.Features.AlarmRepository
{
   public class AlarmRepository : IMainPageFeatures
   {
       private readonly HashSet<string> alarms;

       public AlarmRepository(HashSet<string> alarms)
       {
           this.alarms = alarms;
       }

       public void AddAlarm(Location targetLocation)
       {
           alarms.Add(targetLocation.Name);
       }
    }
}
