using MyHomeAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHomeAPI.Models
{
    public class SetPointService : ISetPointnService
    {
        private readonly HomeAPIDataContext _context;

        public SetPointService(HomeAPIDataContext context)
        {
            _context = context;
        }

        public bool AddOrUpdate(SetPointData item)
        {
            bool elemetUpdated = false;

            if (item != null && !string.IsNullOrEmpty(item.SetPointName))
            {
                SetPointData existingItem = null;

                existingItem = _context.SetPoints.Where(sp => sp.SetPointName == item.SetPointName).FirstOrDefault();

                if (existingItem != null)
                {
                    //update it
                    existingItem.Value = item.Value;
                    item.LastUpdate = DateTime.UtcNow;
                    existingItem.LastUpdate = item.LastUpdate;
                    _context.SaveChanges();
                }
                else
                {
                    //just add it
                    item.LastUpdate = DateTime.UtcNow;
                    _context.SetPoints.Add(item);
                    _context.SaveChanges();
                }
            }

            return elemetUpdated;
        }

        public IEnumerable<SetPointData> GetAll()
        {
            //easy one just return all the items in the DB
            return _context.SetPoints.ToList();
        }

        public SetPointData GetSetPoint(string setPointName)
        {
            if (!string.IsNullOrEmpty(setPointName))
            {
                SetPointData existingItem = null;

                existingItem = _context.SetPoints.Where(sp => sp.SetPointName == setPointName).FirstOrDefault();

                if (existingItem != null)
                {
                    return existingItem;
                }
            }

            return null;
        }
    }
}