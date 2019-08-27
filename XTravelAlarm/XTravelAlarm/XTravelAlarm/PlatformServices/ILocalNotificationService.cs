using System;
namespace XTravelAlarm.PlatformServices
{
    public interface ILocalNotificationService
    {
        void LocalNotification(string title, string body, Guid id);
        void CancelNotification(int notifyId);
    }
}
