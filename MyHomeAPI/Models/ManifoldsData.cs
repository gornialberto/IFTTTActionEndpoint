using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace MyHomeAPI.Models
{
    public class ManifoldsData
    {
        public long? TimeStamp { get; set; }

        public string ReadeableTimeStamp
        {
            get
            {
                if (this.TimeStamp.HasValue)
                {
                    return DateTimeOffset.FromUnixTimeMilliseconds(this.TimeStamp.Value).ToString(DateTimeFormatInfo.InvariantInfo.UniversalSortableDateTimePattern);
                }

                return string.Empty;
            }
        }

        public double ZonaAHotTemperature {get;set;}
        public double ZonaAColdTemperature { get; set; }
        public double ZonaBHotTemperature { get; set; }
        public double ZonaBColdTemperature { get; set; }
    }
}
