using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using MatplotlibCS;
using MatplotlibCS.PlotItems;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpecianBP.Api;
using SpecianBP.Api.Dto;
using SpecianBP.Api.PlotExportModels;
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
        protected readonly MatplotLibParamsMappingService _matplotLibParamsMappingService;

        public SeriesController(DbService dbService, SeriesService seriesService, MatplotLibParamsMappingService matplotLibParamsMappingService)
        {
            _dbService = dbService;
            _seriesService = seriesService;
            _matplotLibParamsMappingService = matplotLibParamsMappingService;
        }

        /// <summary>
        /// Divides range by step, and all values in each interval averages.
        /// </summary>
        // GET api/values
        [HttpGet("SingleSeriesAveraged")]
        public ActionResult<IEnumerable<SeriesAveragedDto>> GetAvergaed(
            [FromHeader] DateTime From,
            [FromHeader] DateTime To,
            [FromHeader] TimeSpan Step,
            [FromHeader] string SeriesName,
            [FromHeader] int MeasurementPlaceNumberId
        )
        {
            if (From == null || From >= To)
            {
                From = defaultValuesFrom;
                To = defaultValuesTo;
            }

            var result = _seriesService.GetAveraged(From, To, Step, SeriesName, MeasurementPlaceNumberId);


            return Ok(result);
        }

        [HttpPost("Export")]
        public ActionResult Export([FromBody] MultilinePlotParams[] plotParams, [FromQuery] string fileName = "PlotExportPdf.pdf")
        {
            if(plotParams == null || plotParams.Length == 0 || string.IsNullOrEmpty(fileName))
            {
                return BadRequest();
            }

            string tempfolder = System.IO.Path.GetTempPath();
            tempfolder = "C:\\Users\\King\\Documents\\BP\\";
            string pythonExe = "C:\\Users\\King\\AppData\\Local\\Programs\\Python\\Python37\\python.exe";
            string plotPath = "C:\\Users\\King\\source\\repos\\MatplotlibTest\\MatplotlibTest\\MatplotlibCS\\matplotlib_cs.py";
            var matplotLibEngine = new MatplotlibCS.MatplotlibCS(pythonExe, plotPath);

            var figure = _matplotLibParamsMappingService.getMatplotLibFigureFromPlotParams(plotParams, tempfolder + fileName);
            var t = matplotLibEngine.BuildFigure(figure);
            t.Wait();
            Task.WaitAll(t);
            return Ok("exported");
        }
    }
}