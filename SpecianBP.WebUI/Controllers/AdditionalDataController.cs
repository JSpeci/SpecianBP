using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpecianBP.Db;
using SpecianBP.Entities;

namespace SpecianBP.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdditionalDataController : ControllerBase
    {
        protected readonly DbService _dbService;

        public AdditionalDataController(DbService context)
        {
            _dbService = context;
        }

        // GET api/values
        [HttpGet("PowerSeriesNames")]
        public ActionResult<IEnumerable<string>> Get()
        {
            var names = typeof(Power).GetProperties()
                        .Select(property => property.Name)
                        .ToList();

            var names2 = typeof(Entity).GetProperties()
                        .Select(property => property.Name)
                        .ToList();

            names2.Add("TimeLocal"); // ommit time local in requested series names

            var resultNames = names.Except(names2);

            return Ok(resultNames);
        }

        // GET api/values
        [HttpGet("GetSeriesUnit")]
        public ActionResult<string> GetSeriesUnit([FromHeader] string SeriesName)
        {
            var u = _dbService.SeriesUnit.Where(i => i.SeriesName == SeriesName).FirstOrDefault();

            if (u != null)
            {
                return u.UnitName;
            }
            else return "";
        }

    }
}