using MyHomeAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHomeAPI.Models
{
    public class IFTTTActionService : IIFTTTActionService
    {
        private readonly HomeAPIDataContext _context;

        public IFTTTActionService(HomeAPIDataContext context)
        {
            _context = context;
        }

        public IFTTTActionData Add(IFTTTActionData item)
        {
            if (item != null && !string.IsNullOrEmpty(item.ActionName))
            {   
                //just add it
                item.ReceivedTimeStamp = DateTime.UtcNow;
                _context.IFTTTActionsData.Add(item);
                _context.SaveChanges();
                
            }

            return item;
        }


        /// <summary>
        /// Get all not processed action
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IFTTTActionData> GetAllNotProcessed()
        {
            //easy one just return all the items in the DB
            return _context.IFTTTActionsData.Where(item => item.Processed == false);
        }

        /// <summary>
        /// Get all not processed action by action name
        /// </summary>
        /// <param name="actionName"></param>
        /// <returns></returns>
        public IEnumerable<IFTTTActionData> GetAllNotProcGetAllNotProcessedForActionessed(string actionName)
        {
            return _context.IFTTTActionsData.Where(item => item.ActionName == actionName && item.Processed == false);
        }
    }
}
