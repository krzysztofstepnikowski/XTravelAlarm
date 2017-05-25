using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XTravelAlarm.Features;

namespace XTravelAlarm.Repository
{
    public interface IAlarmRepository
    {
        Task Add(AlarmLocation alarmLocation);
        Task Remove(Guid id);
        Task<List<AlarmLocation>> GetAll();
        Task<AlarmLocation> GetById(Guid id);

    }
}
