using System;
using System.Collections.Generic;
using System.Text;

namespace SpecianBP.Entities
{
    public class SavedDashboardModel : Entity
    {
        public string Name { get; set; }
        public string JSONparamas { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
    }
}
