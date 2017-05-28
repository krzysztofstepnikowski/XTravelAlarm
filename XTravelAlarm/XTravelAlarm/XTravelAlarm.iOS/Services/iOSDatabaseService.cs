using System;
using System.IO;
using SQLite;
using Xamarin.Forms;
using XTravelAlarm.Services;
using XTravelAlarm.iOS.Services;

[assembly: Dependency(typeof(iOSDatabaseService))]

namespace XTravelAlarm.iOS.Services
{

    public class iOSDatabaseService : IDatabaseService
    {

        public iOSDatabaseService()
        {
        }

        public SQLiteAsyncConnection GetConnection()
        {
            var sqliteFilename = "alarms.db3";
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
            string libraryPath = Path.Combine(documentsPath, "..", "Library"); // Library folder
            var path = Path.Combine(libraryPath, sqliteFilename);
            // Create the connection
            var conn = new SQLiteAsyncConnection(path);
            // Return the database connection
            return conn;
        }
    }
}
