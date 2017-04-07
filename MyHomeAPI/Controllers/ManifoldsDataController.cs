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
        public IManifoldsDataService Repository { get; set; }

        public ManifoldsDataController(IManifoldsDataService repository)
        {
            Repository = repository;
        }


        [HttpGet("all")]
        public IEnumerable<ManifoldsData> GetAll()
        {
            return Repository.GetAll();
        }

        [HttpGet("last")]
        public ManifoldsData GetLast()
        {
            return Repository.GetLast();
        }

        [HttpPost]
        public IActionResult Create([FromBody] ManifoldsData item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            Repository.Add(item);

            return Ok(item);
        }
    }
}
