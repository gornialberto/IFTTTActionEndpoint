using MyHomeAPI.Data;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHomeAPI.Models
{
    public class ManifoldsDataService : IManifoldsDataService
    {
        private readonly HomeAPIDataContext _context;

        public ManifoldsDataService(HomeAPIDataContext context)
        {
            _context = context;
        }

        public IEnumerable<ManifoldsData> GetAll()
        {
            //easy one just return all the items in the DB
            return _context.ManifoldsData.ToList();
        }

        public ManifoldsData Add(ManifoldsData item)
        {
            item.TimeStamp = DateTime.UtcNow; //DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

            _context.ManifoldsData.Add(item);
            _context.SaveChanges();

            return item;
        }

        public ManifoldsData GetLast()
        {
            return _context.ManifoldsData.OrderByDescending(item => item.TimeStamp).FirstOrDefault();
        }
    }
}
