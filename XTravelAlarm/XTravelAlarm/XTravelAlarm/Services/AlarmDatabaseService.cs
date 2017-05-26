using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XTravelAlarm.Features;
using XTravelAlarm.Features.AlarmRinging.Storage;

namespace XTravelAlarm.Services
{
    public class AlarmDatabaseService : IAlarmDatabaseService
    {
        protected SQLiteAsyncConnection DbConnection { get; set; }
        public AlarmDatabaseService(SQLiteAsyncConnection connection)
        {
            DbConnection = connection;
        }

        public Task<List<AlarmLocation>> GetAllAsync()
        {
            return DbConnection.Table<AlarmLocation>().ToListAsync();
        }

        public Task<AlarmLocation> GetAlarmAsync(Guid id)
        {
            return DbConnection.Table<AlarmLocation>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public Task AddAlarmAsync(AlarmLocation alarmlocation)
        {
            return DbConnection.InsertAsync(alarmlocation);
        }

        public Task RemoveAlarmAsync(Guid id)
        {
            return DbConnection.DeleteAsync(id);
        }

    }
}
