using SQLite;

namespace XTravelAlarm.Services
{
    public interface ILocalFileHelper
    {
        SQLiteAsyncConnection Connection { get; }
    }
}
