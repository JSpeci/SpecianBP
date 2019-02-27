using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpecianBP.Entities
{
    public abstract class SoftDeletableEntity : Entity
    {
        public bool? IsDeleted { get; set; }
    }
}
