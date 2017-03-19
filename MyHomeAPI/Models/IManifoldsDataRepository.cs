using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHomeAPI.Models
{
    public interface IManifoldsDataRepository
    {
        void Add(ManifoldsData item);
        IEnumerable<ManifoldsData> GetAll();
        ManifoldsData GetLast();
        ManifoldsData Find(long timeStamp);
        ManifoldsData Remove(long timeStamp);
        void Update(ManifoldsData item);
    }
}
