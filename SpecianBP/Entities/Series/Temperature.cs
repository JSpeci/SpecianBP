using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpecianBP.Entities
{
    public class Temperature : Entity
    {
        public DateTime TimeLocal { get; set; }
        //originalName = Inputs/Temperature_avg_Ti_C
        public float Inputs_Temperature_avg_Ti_C { get; set; }
    }
}
