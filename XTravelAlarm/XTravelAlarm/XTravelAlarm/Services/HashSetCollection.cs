using System;
using System.Collections.Generic;
using XTravelAlarm.Services.Interfaces;

namespace XTravelAlarm.Services
{
    public class HashSetCollection : IHashSetCollection
    {
        private HashSet<Guid> _hashSet;

        public HashSetCollection()
        {
            _hashSet = new HashSet<Guid>();
        }


        public HashSet<Guid> InitalizeCollection()
        {
            return _hashSet;
        }

        public void Add(Guid alarmLocationId)
        {
            _hashSet.Add(alarmLocationId);
        }

        public void Remove(Guid alarmLocationId)
        {
            _hashSet.Remove(alarmLocationId);
        }
    }
}
