using MyHomeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHomeAPI.Controllers
{
    [Route("api/[controller]")]
    public class SetPointController : Controller
    {
        public ISetPointnService SetPointService { get; set; }

        public SetPointController(ISetPointnService setPointService)
        {
            SetPointService = setPointService;
        }


        [HttpGet]
        public IEnumerable<SetPointData> GetAll()
        {
            return SetPointService.GetAll();
        }


        [HttpPost]
        public IActionResult Create([FromBody] SetPointData item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            SetPointService.AddOrUpdate(item);

            return Created(item.SetPointName,item);
        }

        [HttpGet("{setPointName}")]
        public IActionResult Get(string setPointName)
        {
            SetPointData aSetPoint = SetPointService.GetSetPoint(setPointName);

            if (aSetPoint != null)
                return this.Ok(aSetPoint);
            else
                return NotFound();
        }
    }
}
