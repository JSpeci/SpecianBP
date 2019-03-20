using System;
using System.Collections.Generic;
using System.Text;

namespace SpecianBP.Entities
{
    public class MeasurementPlace
    {
        public Guid Id { get; set; }
        public int NumberId { get; set; }
        public string DisplayName { get; set; }
        public string FileName { get; set; }
        public string Adress { get; set; }
    }
}
