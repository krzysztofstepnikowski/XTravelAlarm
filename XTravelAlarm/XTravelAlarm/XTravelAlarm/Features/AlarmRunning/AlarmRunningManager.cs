using System.Collections.Generic;

namespace XTravelAlarm.Features.AlarmRunning
{
    public class AlarmRunningManager
    {
        private readonly HashSet<AlarmLocation> alarmsRunning;

        public AlarmRunningManager(HashSet<AlarmLocation> alarmsRunning)
        {
            this.alarmsRunning = alarmsRunning;
        }

        public void SetAsAlarmRunning(AlarmLocation alarmLocation)
        {
            alarmsRunning.Add(alarmLocation);
        }

        public void RemoveFromAlarmsRunning(AlarmLocation alarmLocation)
        {
            alarmsRunning.Remove(alarmLocation);
        }
    }
}
