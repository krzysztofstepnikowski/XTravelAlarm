using System.Collections.Generic;
using XTravelAlarm.Models;

namespace XTravelAlarm.Views.Alarms
{
    public interface IAlarmPageFeatures
    {
        IEnumerable<AlarmLocationViewModel> GetAll();
    }
}