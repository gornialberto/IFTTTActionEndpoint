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
        public IEnumerable<IFTTTActionData> GetAll()
        {
            return null; //IFTTTActionService.GetAll();
        }


        [HttpPost]
        public IActionResult Create([FromBody] IFTTTActionData item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            IFTTTActionService.Add(item);

            return Create(item);
        }
    }
}
