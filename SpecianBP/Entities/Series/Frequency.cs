using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpecianBP.Entities
{
    public class Frequency : SeriesEntity
    {
        public DateTime TimeLocal { get; set; }
        public float f_avg_f_C { get; set; }
        //public float D_avg_D4_C { get; set; }
        public float D_avg_D3_C { get; set; }
        public float D_avg_D2_C { get; set; }
        public float D_avg_D1_C { get; set; }
        public float D_avg_3D_C { get; set; }
        //public float Cos_Cos4_C { get; set; }
        public float Cos_Cos3_C { get; set; }
        public float Cos_Cos2_C { get; set; }
        public float Cos_Cos1_C { get; set; }
        public float Cos_3Cos_C { get; set; }
    }
}
