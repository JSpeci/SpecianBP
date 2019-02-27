using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpecianBP.DataProtection
{
    public interface IGrantsHolder
    {
        IEnumerable<IGrant> Grants { get; }
    }
}
