using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpecianBP.Entities
{
    public abstract class Entity
    {
        public Entity()
        {
            Id = Guid.NewGuid();
            CreateDate = DateTimeOffset.Now;
        }

        public Guid Id { get; set; }
        public DateTimeOffset CreateDate { get; set; }


    }
}
