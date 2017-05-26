using System;
using System.IO;
using SQLite;
using Xamarin.Forms;
using XTravelAlarm.Droid.Services;
using XTravelAlarm.Services;

[assembly: Dependency(typeof(DroidLocalFileHelper))]
namespace XTravelAlarm.Droid.Services
{
    public class DroidLocalFileHelper : ILocalFileHelper
    {
        private SQLiteAsyncConnection connection;
        public SQLiteAsyncConnection Connection
        {
            get
            {
                if(connection==null)
                {
                    if (connection == null)
                    {
                        var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                                                "alarms.db");

                        connection = new SQLiteAsyncConnection(path);
                    }
                }

                return connection;
            }
        }
    }
}