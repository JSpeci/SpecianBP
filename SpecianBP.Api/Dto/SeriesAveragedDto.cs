using System;
using System.Collections.Generic;
using System.Text;

namespace SpecianBP.Api.Dto
{
    public class SeriesAveragedDto
    {
        public DateTime FromTime { get; set; }
        public DateTime ToTime { get; set; }
        public float AverageValue { get; set; }
        public float MaxValue { get; set; }
        public float MinValue { get; set; }
        public string SeriesName { get; set; }

        public SeriesAveragedDto()
        {

        }

        public override string ToString()
        {
            return $"{SeriesName} {AverageValue} {FromTime} {ToTime} ";
        }
    }
}
