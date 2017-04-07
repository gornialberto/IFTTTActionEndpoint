using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace MyHomeAPI.Models
{
    public class ManifoldsData
    {
        //DateTimeOffset.FromUnixTimeMilliseconds
        [Key]
        [DataType(DataType.Date)]
        public DateTime TimeStamp { get; set; }

        public string ReadeableTimeStamp
        {
            get
            {
                    return this.TimeStamp.ToString(DateTimeFormatInfo.InvariantInfo.UniversalSortableDateTimePattern);
            }
        }

        public double ZonaAHotTemperature {get;set;}
        public double ZonaAColdTemperature { get; set; }
        public double ZonaBHotTemperature { get; set; }
        public double ZonaBColdTemperature { get; set; }
    }
}
