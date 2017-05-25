using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        public Task Add(AlarmLocation alarmLocation)
        {
            return Task.Run(() =>
            {
                lock (databaseLock)
                {
                    DbConnection.Insert(alarmLocation);
                }
            });
        }

        public Task<List<AlarmLocation>> GetAll()
        {
            List<AlarmLocation> alarms;

            lock(databaseLock)
            {
                alarms = DbConnection.Table<AlarmLocation>().ToList();
            }

            return Task.FromResult(alarms);
        }

        public Task<AlarmLocation> GetById(Guid id)
        {
            AlarmLocation alarmLocation;

            lock(databaseLock)
            {
                alarmLocation = DbConnection.Table<AlarmLocation>().FirstOrDefault(x => x.Id == id);
            }

            return Task.FromResult(alarmLocation);
        }

        public Task Remove(Guid id)
        {
            return Task.Run(() =>
            {
                lock (databaseLock)
                {
                    DbConnection.Delete<AlarmLocation>(id);
                }
            });
        }
    }
}
