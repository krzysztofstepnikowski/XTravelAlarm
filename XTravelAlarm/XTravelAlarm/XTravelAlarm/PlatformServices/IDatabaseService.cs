using SQLite;

namespace XTravelAlarm.PlatformServices
{
    public interface IDatabaseService
    {
        SQLiteAsyncConnection GetConnection();
    }
}
