using System;

namespace XTravelAlarm.Features.AlarmRinging
{
   public interface INotificationService
   {
       void Show(string title, string message, DateTime time);
   }
}
