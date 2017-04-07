using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHomeAPI.Models
{
    public interface ISetPointnService
    {
        /// <summary>
        /// Add or Update a SetPoint item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool AddOrUpdate(SetPointData item);

        /// <summary>
        /// Get all the Set Point Data
        /// </summary>
        /// <returns></returns>
        IEnumerable<SetPointData> GetAll();

        /// <summary>
        /// Get a particular SetPoint
        /// </summary>
        /// <param name="setPointName"></param>
        /// <returns></returns>
        SetPointData GetSetPoint(string setPointName);
    }
}
