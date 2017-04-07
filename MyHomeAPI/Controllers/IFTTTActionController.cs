using MyHomeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHomeAPI.Controllers
{
    [Route("api/[controller]")]
    public class IFTTTActionController : Controller
    {
        public IIFTTTActionService IFTTTActionService { get; set; }

        public IFTTTActionController(IIFTTTActionService iftttActionService)
        {
            IFTTTActionService = iftttActionService;
        }


        [HttpGet]
        public IEnumerable<IFTTTActionData> GetAllNotProcessed()
        {
            return IFTTTActionService.GetAllNotProcessed();
        }

        [HttpGet("{actionName}")]
        public IEnumerable<IFTTTActionData> GetAllNotProcessedForAction(string actionName)
        {
            return IFTTTActionService.GetAllNotProcGetAllNotProcessedForActionessed(actionName);
        }


        [HttpPost("{actionName}")]
        public IActionResult Create(string actionName, [FromBody]Newtonsoft.Json.Linq.JObject content)
        {
            //+content {
            //    {
            //        "ActionBodyContent": {
            //            "innerContent": "value"
            //        }
            //    }
            //}
            //object { Newtonsoft.Json.Linq.JObject}

            //dynamic results = JsonConvert.DeserializeObject<dynamic>(json);
            //var id = results.Id;
            //var name = results.Name;

            if (string.IsNullOrEmpty(actionName))
            {
                return BadRequest();
            }

            IFTTTActionData item = new IFTTTActionData();

            item.ActionName = actionName;
            item.ActionBodyContent = content.ToString(Newtonsoft.Json.Formatting.None);

            IFTTTActionService.Add(item);

            return Created(item.ActionName, item);
        }
    }
}
