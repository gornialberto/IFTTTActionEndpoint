using MyHomeAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHomeAPI.Models
{
    public class SetPointService : ISetPointnService
    {
        private readonly SetPointDataContext _context;

        public SetPointService(SetPointDataContext context)
        {
            _context = context;
        }

        public void Add(SetPointData item)
        {
            _context.SetPoints.Add(item);
            _context.SaveChanges();
        }

        public IEnumerable<SetPointData> GetAll()
        {
            return _context.SetPoints.ToList();
        }
    }
}
