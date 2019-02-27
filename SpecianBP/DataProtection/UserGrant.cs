using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpecianBP.DataProtection
{
    public class UserGrant : IGrant
    {
        public UserGrant(string id, string name, Func<IEnumerable<IGrant>> getIncludedGrantsFunc)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException("Grant id cannot be null or empty");
            }
            Id = id;
            Name = name ?? Id;
            _getIncludedGrantsFunc = getIncludedGrantsFunc;
        }

        public UserGrant(string id, Func<IEnumerable<IGrant>> getIncludedGrantsFunc) : this(id, null, getIncludedGrantsFunc)
        {

        }

        public UserGrant(string id, string name) : this(id, name, null)
        {

        }

        public UserGrant(string id) : this(id, null, null)
        {

        }

        private readonly Func<IEnumerable<IGrant>> _getIncludedGrantsFunc;
        public string Id { get; }
        public string Name { get; }
        public IEnumerable<IGrant> IncludedGrants => _getIncludedGrantsFunc?.Invoke();
    }
}
