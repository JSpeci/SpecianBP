using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpecianBP.Db;
using SpecianBP.Entities;

namespace SpecianBP.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        protected readonly DbService _dbService;

        public readonly DateTime defaultValuesFrom = new DateTime(2018, 4, 1);
        public readonly DateTime defaultValuesTo = new DateTime(2018, 4, 30);


        public ValuesController(DbService context)
        {
            _dbService = context;
        }


        //We dont use DTOS, all Series entitites are only getted   !!!!!!

        // GET api/values
        [HttpGet("Power")]
        public ActionResult<IEnumerable<Power>> Get([FromBody] DateTime from, [FromBody] DateTime to)
        {       
            if(from == null)
            {
                from = defaultValuesFrom;
                to = defaultValuesTo;
            }

            IEnumerable<Power> powers = _dbService.Power
                .Where(i => i.TimeLocal >= from && i.TimeLocal <= to)
                .OrderBy(i => i.TimeLocal)
                .ToList();
            return Ok(powers);
        }


        // GET api/values
        [HttpGet("PowerSingleSeries")]
        public ActionResult<IEnumerable<Power>> Get([FromBody] DateTime from, [FromBody] DateTime to, string seriesName)
        {
            if (from == null)
            {
                from = defaultValuesFrom;
                to = defaultValuesTo;
            }

            IEnumerable<Power> powers = _dbService.Power
                .Where(i => i.TimeLocal >= from && i.TimeLocal <= to)
                .OrderBy(i => i.TimeLocal)
                .ToList();
            return Ok(powers);
        }
    }
}
