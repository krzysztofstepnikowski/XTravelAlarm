using SQLite;

namespace XTravelAlarm.Services
{
    public interface IDatabaseService
    {
        SQLiteAsyncConnection GetConnection();
    }
}
