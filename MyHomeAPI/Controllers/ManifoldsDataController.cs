using MyHomeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHomeAPI.Controllers
{
    [Route("api/[controller]")]
    public class ManifoldsDataController : Controller
    {
        public IManifoldsDataRepository Repository { get; set; }

        public ManifoldsDataController(IManifoldsDataRepository repository)
        {
            Repository = repository;
        }


        [HttpGet]
        public IEnumerable<ManifoldsData> GetAll()
        {
            return Repository.GetAll();
        }


        [HttpGet("{timeStamp}", Name = "GetManifoldData")]
        public IActionResult GetById(long timeStamp)
        {
            var item = Repository.Find(timeStamp);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] ManifoldsData item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            Repository.Add(item);
            return CreatedAtRoute("GetManifoldData", new { timeStamp = item.TimeStamp }, item);
        }
    }
}
