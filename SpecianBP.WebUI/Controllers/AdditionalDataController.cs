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
        public ActionResult<IEnumerable<string>> GetPowerSeriesNames()
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
        [HttpGet("AllSeriesNames")]
        public ActionResult<IEnumerable<string>> GetAllSeriesNames()
        {
            var names = typeof(Power).GetProperties()
                        .Select(property => property.Name)
                        .ToList();

            names.AddRange(
            typeof(Voltage).GetProperties()
                .Select(property => property.Name)
                .ToList()
            );
            names.AddRange(
            typeof(Current).GetProperties()
                .Select(property => property.Name)
                .ToList()
            );
            names.AddRange(
            typeof(Frequency).GetProperties()
                .Select(property => property.Name)
                .ToList()
            );
            names.AddRange(
            typeof(Status).GetProperties()
                .Select(property => property.Name)
                .ToList()
            );
            names.AddRange(
            typeof(Temperature).GetProperties()
                .Select(property => property.Name)
                .ToList()
            );

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