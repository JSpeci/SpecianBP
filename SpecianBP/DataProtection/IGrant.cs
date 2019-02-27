using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpecianBP.DataProtection
{
    public interface IGrant
    {
        string Id { get; }
        string Name { get; }

        IEnumerable<IGrant> IncludedGrants { get; }
    }
}
