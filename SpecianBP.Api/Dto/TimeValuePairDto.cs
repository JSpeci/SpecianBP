using System;

namespace SpecianBP.Api
{
    public class TimeValuePairDto
    {
        public DateTime Time { get; set; }
        public float Value { get; set; }
        public string SeriesName { get; set; }

        public TimeValuePairDto(DateTime time, float value, string seriesName)
        {
            Time = time;
            Value = value;
            SeriesName = seriesName;
        }

        public override string ToString()
        {
            return $"{SeriesName} {Value} {Time} ";
        }
    }
}
