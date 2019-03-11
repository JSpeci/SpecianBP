using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpecianBP.Api;
using SpecianBP.Api.Dto;
using SpecianBP.Db;
using SpecianBP.Entities;
using SpecianBP.Services;

namespace SpecianBP.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesController : ControllerBase
    {
        public static readonly DateTime defaultValuesFrom = new DateTime(2018, 4, 1);
        public static readonly DateTime defaultValuesTo = new DateTime(2018, 4, 30);

        protected readonly DbService _dbService;
        protected readonly SeriesService _seriesService;

        public SeriesController(SeriesService seriesService, DbService dbService)
        {
            _seriesService = seriesService;
            _dbService = dbService;
        }

        /// <summary>
        /// Divides range by step, and all values in each interval averages.
        /// </summary>
        // GET api/values
        [HttpGet("SingleSeriesAveraged")]
        public ActionResult<IEnumerable<SeriesAveragedDto>> GetAvergaed([FromHeader] DateTime From, [FromHeader] DateTime To, [FromHeader] TimeSpan Step, [FromHeader] string SeriesName)
        {
            if (From == null || From >= To)
            {
                From = defaultValuesFrom;
                To = defaultValuesTo;
            }

            var result = _seriesService.GetAveraged(From, To, Step, SeriesName);
            

            return Ok(result);
        }
    }
}