using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpecianBP.DataProtection
{
    public static class GrantExtensions
    {
        /// <summary>
        /// Get the Id of the grant and ids of all the included grants
        /// </summary>
        /// <param name="grant"></param>
        /// <returns></returns>
        public static IList<string> GetGrantIds(this IGrant grant)
        {
            var result = new List<string> { grant.Id };
            if (grant.IncludedGrants != null && grant.IncludedGrants.Any())
            {
                result.AddRange(grant.IncludedGrants.SelectMany(x => x.GetGrantIds()));
            }

            return result;
        }
    }
}
