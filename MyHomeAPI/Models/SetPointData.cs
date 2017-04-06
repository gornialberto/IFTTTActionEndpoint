using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyHomeAPI.Models
{
    public class SetPointData
    {
        [Key]
        public string SetPointName { get; set; }

        public string Value { get; set; }

        [DataType(DataType.Date)]
        public long LastUpdate { get; set; }
    }
}
