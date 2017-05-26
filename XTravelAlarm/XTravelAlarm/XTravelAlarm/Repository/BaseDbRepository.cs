using SQLite.Net;

namespace XTravelAlarm.Repository
{
    public class BaseDbRepository
    {
        protected static object databaseLock = new object();

        protected SQLiteConnection DbConnection { get; set; }

        public BaseDbRepository(SQLiteConnection connection)
        {
            DbConnection = connection;
        }
    }
}
