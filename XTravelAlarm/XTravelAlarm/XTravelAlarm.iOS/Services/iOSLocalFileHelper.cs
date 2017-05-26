using System;
using System.IO;
using SQLite;
using Xamarin.Forms;
using XTravelAlarm.iOS.Services;
using XTravelAlarm.Services;

[assembly: Dependency(typeof(iOSLocalFileHelper))]
namespace XTravelAlarm.iOS.Services
{
    public class iOSLocalFileHelper : ILocalFileHelper
    {
        private SQLiteAsyncConnection connection;
        public SQLiteAsyncConnection Connection
        {
            get
            {
                if (connection == null)
                {
                    var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                                            "alarms.db");

                    connection = new SQLiteAsyncConnection(path);
                }

                return connection;
            }
        }
    }
}
