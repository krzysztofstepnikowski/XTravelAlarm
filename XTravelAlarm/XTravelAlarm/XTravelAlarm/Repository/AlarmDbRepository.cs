using System;
using System.Collections.Generic;
using SQLite.Net;
using XTravelAlarm.Features;
using System.Linq;

namespace XTravelAlarm.Repository
{
    public class AlarmDbRepository : BaseDbRepository, IAlarmRepository
    {
        public AlarmDbRepository(SQLiteConnection connection) : base(connection)
        {
        }

        public void Add(AlarmLocation alarmLocation)
        {

            lock (databaseLock)
            {
                DbConnection.Insert(alarmLocation);
            }

        }



        public IEnumerable<AlarmLocation> GetAll()
        {
            IEnumerable<AlarmLocation> alarms;

            lock (databaseLock)
            {
                alarms = DbConnection.Table<AlarmLocation>().ToList();
            }

            return alarms;
        }

        public AlarmLocation GetById(Guid id)
        {
            AlarmLocation alarmLocation;

            lock (databaseLock)
            {
                alarmLocation = DbConnection.Table<AlarmLocation>().FirstOrDefault(x => x.Id == id);
            }

            return alarmLocation;
        }

        public void Remove(Guid id)
        {

            lock (databaseLock)
            {
                DbConnection.Delete<AlarmLocation>(id);
            }

        }
    }
}
