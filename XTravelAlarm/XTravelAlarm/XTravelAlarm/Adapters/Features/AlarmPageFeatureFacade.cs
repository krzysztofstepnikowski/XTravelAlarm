using System;
using System.Collections.Generic;
using XTravelAlarm.Features;
using XTravelAlarm.Features.AlarmList;
using XTravelAlarm.Features.GPSobservation;
using XTravelAlarm.Views.Alarms;

namespace XTravelAlarm.Adapters.Features
{
    public class AlarmPageFeatureFacade : IAlarmPageFeatures
    {
        private AlarmListProvider alarmListProvider;
        private GPSListener gpsListener;

        public AlarmPageFeatureFacade(AlarmListProvider alarmListProvider, GPSListener gpsListener)
        {
            this.alarmListProvider = alarmListProvider;
            this.gpsListener = gpsListener;
        }

        public IEnumerable<AlarmLocation> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Add(AlarmLocation alarmLocation)
        {
            throw new NotImplementedException();
        }

        public AlarmLocation GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
