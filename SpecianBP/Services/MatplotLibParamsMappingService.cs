using SpecianBP.Db;
using System;
using System.Collections.Generic;
using System.Text;
using MatplotlibCS;
using MatplotlibCS.PlotItems;
using SpecianBP.Api.PlotExportModels;
using System.Linq;
using SpecianBP.Api.Dto;

namespace SpecianBP.Services
{
    public class MatplotLibParamsMappingService
    {
        //private structs for loading data
        private class MultilinePlotParamsWithData
        {
            public MultilinePlotParams plotParams { get; set; }
            public List<SingleLinePlotWithData> plotData { get; set; }
        }

        private class SingleLinePlotWithData : PlotParams
        {
            public List<SeriesAveragedDto> Data { get; set; }
        }

        public MatplotLibParamsMappingService(DbService context, SeriesService seriesService)
        {
            _dbService = context;
            _seriesService = seriesService;

            posibleLineColors = new List<Color>();
            posibleLineColors.Add(Color.Blue);
            posibleLineColors.Add(Color.Cyan);
            posibleLineColors.Add(Color.Green);
            posibleLineColors.Add(Color.Red);
            posibleLineColors.Add(Color.Black);
            posibleLineColors.Add(Color.Magenta);
            posibleLineColors.Add(Color.Yellow);
        }

        private List<MatplotlibCS.PlotItems.Color> posibleLineColors { get; set; }

        protected readonly DbService _dbService;
        protected readonly SeriesService _seriesService;

        private MultilinePlotParamsWithData BuildPlotDataStruct(MultilinePlotParams plotParams)
        {
            MultilinePlotParamsWithData result = new MultilinePlotParamsWithData();
            result.plotParams = plotParams;
            result.plotData = new List<SingleLinePlotWithData>();
            foreach (var singlePlot in plotParams.plotParams)
            {

                var seriesData = _seriesService.GetAveraged(singlePlot.seriesParams.from, singlePlot.seriesParams.to, singlePlot.seriesParams.line.step, singlePlot.seriesParams.line.seriesName, singlePlot.seriesParams.line.measurementPlaceNumberId);
                var data = new SingleLinePlotWithData() { Data = seriesData, aggrFunc = singlePlot.aggrFunc, chartProps = singlePlot.chartProps, seriesParams = singlePlot.seriesParams };
                result.plotData.Add(data);
            }
            return result;
        }

        public Figure getMatplotLibFigureFromPlotParams(MultilinePlotParams[] plotParams, string pathFithFileName)
        {

            //build figure
            var figure = new Figure(plotParams.Length, 1)
            {
                FileName = pathFithFileName,
                OnlySaveImage = true,
                DPI = 150,
                Width = 1920,
                Height = plotParams.Length > 1 ? 800 * plotParams.Length : 1080,
            };

            var messPlaces = _dbService.MeasurementPlace.ToList();

            int index = 1;
            foreach (var multilinePlot in plotParams)
            {
                var plotData = BuildPlotDataStruct(multilinePlot);

                var plotItemsInSubplot = new List<PlotItem>();

                int indexOfdata = 0;
                foreach (var line in multilinePlot.plotParams)
                {
                    List<double> Ydata = new List<double>();
                    switch (line.aggrFunc)
                    {
                        case "Min":
                            Ydata = plotData.plotData[indexOfdata].Data.Select(i => (double)(i.MinValue)).ToList();
                            break;
                        case "Max":
                            Ydata = plotData.plotData[indexOfdata].Data.Select(i => (double)(i.MaxValue)).ToList();
                            break;
                        case "Average":
                            Ydata = plotData.plotData[indexOfdata].Data.Select(i => (double)(i.AverageValue)).ToList();
                            break;
                    }
                    var item = new Line2D($"{line.seriesParams.line.seriesName} {messPlaces.Where(i => i.NumberId == line.seriesParams.line.measurementPlaceNumberId).First().DisplayName} period: {line.seriesParams.line.step} aggrFunc: {line.aggrFunc}")
                    {
                        //select different colors
                        Color = posibleLineColors[indexOfdata % posibleLineColors.Count],
                        LineWidth = line.chartProps.lineWidth,
                        X = plotData.plotData[indexOfdata].Data.Select(i => i.FromTime).Cast<object>().ToList(),
                        Y = Ydata,

                    };
                    plotItemsInSubplot.Add(item);
                    indexOfdata++;
                }

                var axes = new Axes(index, "", plotData.plotData.First().Data.First().Unit)
                {
                    Title = "\n\n",
                    LegendBorder = false,
                    LegendLocation = LegendLocation.UpperLeft,
                    PlotItems = plotItemsInSubplot,
                };

                figure.Subplots.Add(axes);
                index++;
            }

            return figure;
        }
    }
}
