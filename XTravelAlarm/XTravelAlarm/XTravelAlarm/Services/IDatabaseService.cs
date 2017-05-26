using SQLite.Net;

namespace XTravelAlarm.Services
{
    public interface IDatabaseService
    {
        SQLiteConnection Connection { get; }
    }
}
