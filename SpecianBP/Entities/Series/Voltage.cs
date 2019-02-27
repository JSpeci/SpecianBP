using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpecianBP.Entities
{
    public class Voltage : Entity
    {
        public DateTime TimeLocal { get; set; }
        public float U_avg_U4_C { get; set; }
        public float U_avg_U31_C { get; set; }
        public float U_avg_U3_C { get; set; }
        public float U_avg_U23_C { get; set; }
        public float U_avg_U2_C { get; set; }
        public float U_avg_U12_C { get; set; }
        public float U_avg_U1_C { get; set; }
    }
}
