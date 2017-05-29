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
        }

        public async Task<IEnumerable<AlarmLocation>> GetAllAsync()
        {
            await  DbConnection.CreateTableAsync<AlarmLocation>();
            return await DbConnection.Table<AlarmLocation>().ToListAsync();
        }

        public async Task<AlarmLocation> GetAlarmAsync(Guid id)
        {
            await DbConnection.CreateTableAsync<AlarmLocation>();
            return await DbConnection.Table<AlarmLocation>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task AddAlarmAsync(AlarmLocation alarmLocation)
        {
            await DbConnection.CreateTableAsync<AlarmLocation>();
            await DbConnection.InsertAsync(alarmLocation);
        }

        public async Task UpdateAlarmAsync(AlarmLocation alarmLocation)
        {
            await DbConnection.CreateTableAsync<AlarmLocation>();
            await DbConnection.UpdateAsync(alarmLocation);
        }

        public async Task RemoveAlarmAsync(AlarmLocation alarmlocation)
        {
            await DbConnection.CreateTableAsync<AlarmLocation>();
            await DbConnection.DeleteAsync(alarmlocation);
        }

      
    }
}
