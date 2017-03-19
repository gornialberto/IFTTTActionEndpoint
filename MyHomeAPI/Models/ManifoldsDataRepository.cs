using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHomeAPI.Models
{
    public class ManifoldsDataRepository : IManifoldsDataRepository
    {
        private static ConcurrentDictionary<long, ManifoldsData> _dataRepo =
                      new ConcurrentDictionary<long, ManifoldsData>();

        public IEnumerable<ManifoldsData> GetAll()
        {
            return _dataRepo.Values;
        }

        public void Add(ManifoldsData item)
        {
            if (item.TimeStamp == null)
                item.TimeStamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            
            _dataRepo[item.TimeStamp.Value] =  item;
        }

        public ManifoldsData Find(long timeStamp)
        {
            ManifoldsData item;
            _dataRepo.TryGetValue(timeStamp, out item);
            return item;
        }

        public ManifoldsData Remove(long timeStamp)
        {
            ManifoldsData item;
            _dataRepo.TryRemove(timeStamp, out item);
            return item;
        }

        public void Update(ManifoldsData item)
        {
            _dataRepo[item.TimeStamp.Value] = item;
        }

        public ManifoldsData GetLast()
        {
            var item = _dataRepo.OrderBy(o => o.Key).FirstOrDefault();

            if (item.Value != null)
            {
                return item.Value;
            }

            return null;
        }

 
    }
}
