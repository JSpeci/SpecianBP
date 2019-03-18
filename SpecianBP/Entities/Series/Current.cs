using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpecianBP.Entities
{
    public class Current : SeriesEntity
    {
        public DateTime TimeLocal { get; set; }
        public float I_avg_IPEc_C { get; set; }
        public float I_avg_INc_C { get; set; }
        public float I_avg_I4_C { get; set; }
        public float I_avg_I3_C { get; set; }
        public float I_avg_I2_C { get; set; }
        public float I_avg_I1_C { get; set; }
        public float I_avg_3I_C { get; set; }
    }
}
