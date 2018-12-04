using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XTravelAlarm.Models.PO;

namespace XTravelAlarm.Views.Alarms
{
    public interface IAlarmPageFeatures
    {
        Task<IEnumerable<AlarmLocationViewModel>> GetAllAsync();
        void Enable(Guid alarmId);
        void Disable(Guid alarmId);
        Task RemoveAlarmAsync(Guid id);
    }
}