using System.IO;
using SQLite;
using Xamarin.Forms;
using XTravelAlarm.Services;
using XTravelAlarm.Droid.Services;

[assembly: Dependency(typeof(DroidDatabaseService))]

namespace XTravelAlarm.Droid.Services
{
    public class DroidDatabaseService : IDatabaseService
    {
        public DroidDatabaseService() { }
        public SQLiteAsyncConnection GetConnection()
        {
            var sqliteFilename = "alarms.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
            var path = Path.Combine(documentsPath, sqliteFilename);
            // Create the connection
            var conn = new SQLiteAsyncConnection(path);
            // Return the database connection
            return conn;
        }
    }
}