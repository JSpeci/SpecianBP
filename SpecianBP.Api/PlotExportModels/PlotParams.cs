using System;
using System.Collections.Generic;
using System.Text;

namespace SpecianBP.Api.PlotExportModels
{
    public class PlotParams
    {
        public string aggrFunc { get; set; }
        public SeriesParams seriesParams { get; set; }
        public ChartProps chartProps { get; set; }
    }
}
