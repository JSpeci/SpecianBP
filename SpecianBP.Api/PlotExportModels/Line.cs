using System;
using System.Collections.Generic;
using System.Text;

namespace SpecianBP.Api.PlotExportModels
{
    public class Line
    {
        public string seriesName { get; set; }
        public TimeSpan step { get; set; }
        public int measurementPlaceNumberId { get; set; }
    }
}
