using System;
using System.Collections.Generic;
using System.Text;

namespace SpecianBP.Api.Dto
{
    public class SeriesAveragedParamsDto
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public TimeSpan Step { get; set; }
        public string SeriesName { get; set; }
        public int MeasurementPlaceNumberId { get; set; }
    }
}
