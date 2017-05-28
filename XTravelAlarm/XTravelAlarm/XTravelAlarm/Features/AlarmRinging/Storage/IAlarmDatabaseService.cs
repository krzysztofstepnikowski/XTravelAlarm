using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace XTravelAlarm.Features.AlarmRinging.Storage
{
    public interface IAlarmDatabaseService
    {
        Task<IEnumerable<AlarmLocation>> GetAllAsync();
        Task<AlarmLocation> GetAlarmAsync(Guid id);
        Task AddAlarmAsync(AlarmLocation alarmLocation);
        Task UpdateAlarmAsync(AlarmLocation alarmLocation);
        Task RemoveAlarmAsync(AlarmLocation alarmlocation);

    }
}
