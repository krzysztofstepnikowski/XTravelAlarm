using System;
using System.Collections.Generic;

namespace XTravelAlarm.Services.Interfaces
{
    public interface IHashSetCollection
    {
        HashSet<Guid> InitalizeCollection();
        void Add(Guid alarmLocationId);
        void Remove(Guid alarmLocationId);
    }
}