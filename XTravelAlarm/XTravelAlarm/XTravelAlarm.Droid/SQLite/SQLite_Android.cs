using System.IO;
using SQLite;
using Xamarin.Forms;
using XamarinForms.SQLite.Droid.SQLite;
using XTravelAlarm.Services;

[assembly: Dependency(typeof(SQLite_Android))]

namespace XamarinForms.SQLite.Droid.SQLite
{
    public class SQLite_Android : IDatabaseService
    {
        public SQLite_Android() { }
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