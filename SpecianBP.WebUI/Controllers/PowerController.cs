using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpecianBP.Api;
using SpecianBP.Api.Dto;
using SpecianBP.Db;
using SpecianBP.Entities;

namespace SpecianBP.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PowerController : ControllerBase
    {
        protected readonly DbService _dbService;

        public readonly DateTime defaultValuesFrom = new DateTime(2018, 4, 1);
        public readonly DateTime defaultValuesTo = new DateTime(2018, 4, 30);


        public PowerController(DbService context)
        {
            _dbService = context;
        }


        //We dont use DTOS, all Series entitites are only getted   !!!!!!

        // GET api/values
        [HttpGet("Power")]
        public ActionResult<IEnumerable<Power>> Get([FromHeader] DateTime from, [FromHeader] DateTime to)
        {
            if (from.Year != 2018 || to.Year != 2018)
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

        /// <summary>
        /// Divides range by step, and all values in each interval averages.
        /// </summary>
        // GET api/values
        [HttpGet("SingleSeriesAveraged")]
        public ActionResult<IEnumerable<SeriesAveragedDto>> GetAvergaed([FromHeader] DateTime From, [FromHeader] DateTime To, [FromHeader] TimeSpan Step, [FromHeader] string SeriesName)
        {
            if(From == null)
            {
                From = defaultValuesFrom;
                To = defaultValuesTo;
            }

            var powers = _dbService.Power
                .Where(i => i.TimeLocal >= From && i.TimeLocal <= To)
                .OrderBy(i => i.TimeLocal)
                .Select(i => new TimeValuePairDto() { Time = i.TimeLocal, Value = (float)i.GetType().GetProperty(SeriesName).GetValue(i, null), SeriesName = SeriesName })
                .ToList();

            // divide

            DateTime intervalSart = From;
            DateTime intervalEnd = From + Step;

            List<List<TimeValuePairDto>> grouped = new List<List<TimeValuePairDto>>();
            var result = new List<SeriesAveragedDto>();
            bool lastPart = false;
            do
            {
                var group = powers.Where(i => i.Time >= intervalSart && i.Time <= intervalEnd).ToList();
                if(group.Count() > 0)
                {
                    grouped.Add(group);
                    SeriesAveragedDto averaged = new SeriesAveragedDto();
                    averaged.FromTime = intervalSart;
                    averaged.ToTime = intervalEnd;
                    averaged.AverageValue = group.Select(i => i.Value).Average();
                    averaged.SeriesName = SeriesName;
                    averaged.MinValue = group.Select(i => i.Value).Min();
                    averaged.MaxValue = group.Select(i => i.Value).Max();
                    result.Add(averaged);
                    intervalSart = intervalEnd;
                }
                if (intervalEnd + Step > To && !lastPart)
                {
                    intervalEnd = To;
                    lastPart = true;
                }
                else
                {
                    intervalEnd = intervalEnd + Step;
                }
            } while (intervalEnd < (To + Step) || !lastPart);

            return Ok(result);
        }

        // GET api/values
        [HttpGet("SingleSeries")]
        public ActionResult<IEnumerable<TimeValuePairDto>> Get([FromHeader] DateTime from, [FromHeader] DateTime to, [FromHeader] string SeriesName)
        {
            if (from == null)
            {
                from = defaultValuesFrom;
                to = defaultValuesTo;
            }


            var powers = _dbService.Power
                .Where(i => i.TimeLocal >= from && i.TimeLocal <= to)
                .OrderBy(i => i.TimeLocal)
                .Select(i => new { time = i.TimeLocal, value = i.GetType().GetProperty(SeriesName).GetValue(i, null) })
                .ToList();

            var result = new List<TimeValuePairDto>();

            foreach (var p in powers)
            {
                result.Add(new TimeValuePairDto(p.time, (float)p.value, SeriesName));
            }

            return Ok(result);
        }
    }
}