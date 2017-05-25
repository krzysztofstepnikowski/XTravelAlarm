using System;
using SQLite.Net;
using XTravelAlarm.Services;
using System.IO;
using SQLite.Net.Platform.XamarinAndroid;
using XTravelAlarm.Droid.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(DroidDatabaseService))]
namespace XTravelAlarm.Droid.Services
{
    public class DroidDatabaseService : IDatabaseService
    {
        private SQLiteConnection connection;
        public SQLiteConnection Connection
        {
            get
            {
                if (connection == null)
                {
                    var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                                            "alarms.sqlite");

                    connection = new SQLiteConnection(new SQLitePlatformAndroid(), path);
                }

                return connection;
            }
        }
    }
}