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
        public ActionResult Export([FromBody] JsonResult plotParams)
        {


            string tempfolder = System.IO.Path.GetTempPath();
            tempfolder = "C:\\Users\\King\\Documents\\BP\\ExampleSinPDF2222.pdf";

            string pythonExe = "C:\\Users\\King\\AppData\\Local\\Programs\\Python\\Python37\\python.exe";
            //string plotPath = "C:\\Users\\King\\source\\repos\\MatplotlibCS\\MatplotlibCS\\Python\\matplotlib_cs.py";
            string plotPath = "C:\\Users\\King\\source\\repos\\MatplotlibTest\\MatplotlibTest\\MatplotlibCS\\matplotlib_cs.py";
            var matplotLibEngine = new MatplotlibCS.MatplotlibCS(pythonExe, plotPath);

            ;

            #region create test data

            const int N = 100;
            var X = new double[N];
            var Y1 = new double[N];
            var Y2 = new double[N];
            var x = 0.0;
            const double h = 2 * Math.PI / N;
            var rnd = new Random();
            for (var i = 0; i < N; i++)
            {
                var y = Math.Sin(x);
                X[i] = x;
                Y1[i] = y;

                y = Math.Sin(2 * x);
                Y2[i] = y + rnd.NextDouble() / 10.0;

                x += h;
            }

            #endregion

            #region create plot


            var figure = new Figure(1, 1)
            {
                FileName = tempfolder,
                OnlySaveImage = true,
                DPI = 150,
                Width = 1920,
                Height = 1080,
                Subplots =
                {
                    new Axes(1, "The X axis", "The Y axis")
                    {
                        Title = "Sin(x), Sin(2x), VLines, HLines, Annotations",
                        LegendBorder = false,
                        Grid = new Grid()
                        {
                            MinorAlpha = 0.2,
                            MajorAlpha = 1.0,
                            XMajorTicks = new[] {0.0, 7.6, 0.5, 1.75},
                            YMajorTicks = new[] {-1, 2.5, 0.25, 0.125},
                            XMinorTicks = new[] {0.0, 7.25, 0.25, 1.125},
                            YMinorTicks = new[] {-1, 2.5, 0.125, 1.025}
                        },
                        PlotItems =
                        {
                            new Line2D("Sin")
                            {
                                X = X.Cast<object>().ToList(),
                                Y = Y1.ToList(),
                                LineStyle = LineStyle.Dashed
                            },

                            new Line2D("Sin 2x")
                            {
                                X = X.Cast<object>().ToList(),
                                Y = Y2.ToList(),
                                LineStyle = LineStyle.Solid,
                                LineWidth = 0.5f,
                                Color = "r",
                                Markevery = 5,
                                MarkerSize = 10,
                                Marker = Marker.Circle,
                                ShowLegend = false
                            },

                            new Text("ant1", "Text annotation", 4.5, 0.76)
                            {
                                FontSize = 17
                            },

                            new Annotation("ant2","Arrow text annotation", 0.5, -0.7, 3, 0)
                            {
                                Color = "#44ff88",
                                ArrowStyle = ArrowStyle.Both,
                                LineWidth = 3,
                            },

                            new Vline("vert line", new object[] {3.0}, -1, 1),
                            new Hline("hrzt line", new[] {0.1, 0.25, 0.375}, 0, 5) {LineStyle = LineStyle.Dashed, Color = Color.Magenta}
                        }
                    }

                }
            };

            var t = matplotLibEngine.BuildFigure(figure);
            t.Wait();

            #endregion
            Task.WaitAll(t);

            return Ok("exported");
        }
    }
}