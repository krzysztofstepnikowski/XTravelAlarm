using XTravelAlarm.Features;

namespace XTravelAlarm.Views.Main
{
    public interface IMainPageFeatures
    {
        void SaveAlarm(Position targetPosition, double Distance);
    }
}