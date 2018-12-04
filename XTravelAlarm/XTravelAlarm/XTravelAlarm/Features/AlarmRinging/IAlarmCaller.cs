using System;
using System.Threading.Tasks;
using XTravelAlarm.Models;

namespace XTravelAlarm.Features.AlarmRinging
{
    public interface IAlarmCaller
    {
        Task UpdatePosition(Position position, Guid alarmId);
    }
}