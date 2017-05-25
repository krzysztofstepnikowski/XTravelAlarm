using System;
using SQLite.Net;
using XTravelAlarm.Services;
using XTravelAlarm.iOS.Services;
using Xamarin.Forms;
using SQLite.Net.Platform.XamarinIOS;

[assembly: Dependency(typeof(iOSDatabaseService))]
namespace XTravelAlarm.iOS.Services
{
    public class iOSDatabaseService : IDatabaseService
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

                    connection = new SQLiteConnection(new SQLitePlatformIOS(), path);
                }

                return connection;
            }
        }
    }
}
