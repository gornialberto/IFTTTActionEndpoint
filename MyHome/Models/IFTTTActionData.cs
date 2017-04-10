using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyHomeAPI.Models
{
    public class IFTTTActionData
    {
        public IFTTTActionData()
        {
            Processed = false;
        }

        public string ActionName { get; set; }

        //to see if this can be http://www.newtonsoft.com/json/help/html/T_Newtonsoft_Json_Linq_JObject.htm
        public string ActionBodyContent { get; set; }

        public bool Processed { get; set; }

        [DataType(DataType.Date)]
        public DateTime ProcessedTimeStamp { get; set; }

        [Key]
        [DataType(DataType.Date)]
        public DateTime ReceivedTimeStamp { get; set; }
    }
}
