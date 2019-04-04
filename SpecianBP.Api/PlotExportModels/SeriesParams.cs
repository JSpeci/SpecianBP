using System;
using System.Collections.Generic;
using System.Text;

namespace SpecianBP.Api.PlotExportModels
{
    public class SeriesParams
    {
        public DateTime from { get; set; }
        public DateTime to { get; set; }
        public Line line { get; set; }
    }
}
