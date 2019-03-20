using System;
using System.Collections.Generic;
using System.Text;

namespace SpecianBP.Entities
{
    public class SeriesEntity : Entity
    {
        public int? MeasurementPlaceNumberId { get; set; }
        public virtual MeasurementPlace MeasurementPlace { get; set; }
    }
}
