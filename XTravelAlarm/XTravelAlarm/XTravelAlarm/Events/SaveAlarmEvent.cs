using Prism.Events;
using XTravelAlarm.Features;

namespace XTravelAlarm.Events
{
    /**
     * Umożliwia wymianę informacji między viewmodelami
     */

    public class SaveAlarmEvent : PubSubEvent<Location>
    {
    }
}
