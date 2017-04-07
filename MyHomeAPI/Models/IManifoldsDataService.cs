using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHomeAPI.Models
{
    public interface IManifoldsDataService
    {
        ManifoldsData Add(ManifoldsData item);
        IEnumerable<ManifoldsData> GetAll();
        ManifoldsData GetLast();
    }
}
