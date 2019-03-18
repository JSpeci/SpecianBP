using System;
using System.Collections.Generic;
using System.Text;

namespace SpecianBP.Entities
{
    public class SeriesEntity : Entity
    {
        public Guid? MeasurementPlaceId { get; set; }
        public virtual MeasurementPlace MeasurementPlace { get; set; }
    }
}
