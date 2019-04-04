using SpecianBP.Db;
using System;
using System.Collections.Generic;
using System.Text;
using MatplotlibCS;
using MatplotlibCS.PlotItems;
using SpecianBP.Api.PlotExportModels;
using System.Linq;

namespace SpecianBP.Services
{
    public class MatplotLibParamsMappingService
    {
        protected readonly DbService _dbService;

        public MatplotLibParamsMappingService(DbService context)
        {
            _dbService = context;
        }

        public Figure getMatplotLibFigureFromPlotParams(MultilinePlotParams[] plotParams, string pathFithFileName)
        {

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

            var figure = new Figure(1, 1)
            {
                FileName = pathFithFileName,
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

            return figure;
        }
    }
}
