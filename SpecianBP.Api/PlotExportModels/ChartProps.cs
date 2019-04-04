using System;
using System.Collections.Generic;
using System.Text;

namespace SpecianBP.Api.PlotExportModels
{
    public class ChartProps
    {
        public string type { get; set; }
        public int xSize { get; set; }
        public int ySize { get; set; }
        public string xAxisTitle { get; set; }
        public string yAxisTitle { get; set; }
        public int lineWidth { get; set; }
        public LineColor lineColor { get; set; }
    }
}
