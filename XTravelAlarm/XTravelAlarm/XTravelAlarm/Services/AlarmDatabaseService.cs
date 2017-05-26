using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using XTravelAlarm.Features;
using XTravelAlarm.Features.AlarmRinging.Storage;

namespace XTravelAlarm.Services
{
    public class AlarmDatabaseService : IAlarmDatabaseService
    {
        protected SQLiteAsyncConnection DbConnection { get; set; }
        public AlarmDatabaseService()
        {
            DbConnection = DependencyService.Get<IDatabaseService>().GetConnection();
            DbConnection.CreateTableAsync<AlarmLocation>();
        }

        public async Task<IEnumerable<AlarmLocation>> GetAllAsync()
        {
            return await DbConnection.Table<AlarmLocation>().ToListAsync();
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

        public SQLiteAsyncConnection GetConnection()
        {
            throw new NotImplementedException();
        }
    }
}
