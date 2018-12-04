using System;

namespace XTravelAlarm.PlatformServices
{
   public interface INotificationService
   {
       void Show(string title, string message,Guid alarmId);
   }
}
