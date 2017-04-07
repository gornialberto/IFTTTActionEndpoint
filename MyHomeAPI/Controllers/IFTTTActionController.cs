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


        [HttpPost("{actionName}")]
        public IActionResult Create(string actionName, [FromBody]object content)
        {
            //+content {
            //    {
            //        "ActionBodyContent": {
            //            "innerContent": "value"
            //        }
            //    }
            //}
            //object { Newtonsoft.Json.Linq.JObject}


            if (string.IsNullOrEmpty(actionName))
            {
                return BadRequest();
            }

            IFTTTActionData item = new IFTTTActionData();

            item.ActionName = actionName;
            item.ActionBodyContent = content.ToString();

            IFTTTActionService.Add(item);

            return Created(item.ActionName, item);
        }
    }
}
