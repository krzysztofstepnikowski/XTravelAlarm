using System;
using System.IO;
using SQLite;
using Xamarin.Forms;
using XamarinForms.SQLite.iOS.SQLite;
using XTravelAlarm.Services;

[assembly: Dependency(typeof(SQLite_iOS))]

namespace XamarinForms.SQLite.iOS.SQLite
{

    public class SQLite_iOS : IDatabaseService
    {

        public SQLite_iOS()
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
