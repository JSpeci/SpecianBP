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
    public class MeasurementPlacesController : ControllerBase
    {
        protected readonly DbService _dbService;

        public MeasurementPlacesController(DbService dbService)
        {
            _dbService = dbService;
        }

        private MeasurementPlaceDto ToDto(MeasurementPlace mp)
        {
            return new MeasurementPlaceDto() {
                Adress = mp.Adress,
                DisplayName = mp.DisplayName,
                FileName = mp.FileName,
                NumberId = mp.NumberId,
            };
        }

        /// <summary>
        /// Divides range by step, and all values in each interval averages.
        /// </summary>
        // GET api/values
        [HttpGet("All")]
        public ActionResult<IEnumerable<MeasurementPlaceDto>> GetMessPlaces()
        {
            var result = _dbService.MeasurementPlace
                .Select(i => ToDto(i))
                .ToList();

            return Ok(result);
        }

        [HttpGet("{NumberId}")]
        public ActionResult<IEnumerable<MeasurementPlaceDto>> GetMessPlace([FromRoute] int messPlaceNumberId)
        {
            var result = _dbService.MeasurementPlace
                .SingleOrDefault(i => i.NumberId == messPlaceNumberId);

            if(result == null)
            {
                return NotFound($"There is no measurement Place with number Id: {messPlaceNumberId}");
            }

            return Ok(ToDto(result));
        }
    }
}
