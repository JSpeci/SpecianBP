 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpecianBP.DataProtection
{
    public static class GrantsHolderExtensions
    {

        // <summary>
        /// Iterating through the list of grants, checking whether some of them is the grant of interest or some of the included grants (if any) in the grant is the grant of interest
        /// </summary>
        /// <param name="holder"></param>
        /// <param name="grant"></param>
        /// <returns></returns>
        public static bool HasGrant(this IGrantsHolder holder, IGrant grant)
        {
            return holder.HasGrant(grant.Id);
        }
        /// <summary>
        /// Iterating through the list of grants, checking whether some of them is the grant of interest or some of the included grants (if any) in the grant is the grant of interest
        /// </summary>
        /// <param name="holder"></param>
        /// <param name="code">Code/Id of the grant</param>
        /// <returns></returns>
        public static bool HasGrant(this IGrantsHolder holder, string code)
        {
            return holder.Grants.Any(x => CheckGrant(x, code, 1));
        }

        /// <summary>
        /// Iterates through the list of grants, returning code for each grant and for aggregated grants (the ones that include other grants) 
        /// also codes for all the included grants. The resulting list is distinced
        /// </summary>
        /// <param name="holder">Object that holds the list of Grants</param>
        /// <returns>Distinct list of all grantcodes that the holder have</returns>
        public static IEnumerable<string> GetAllGrantsCodes(this IGrantsHolder holder)
        {
            return holder.Grants.SelectMany(x => x.GetGrantIds()).Distinct();
        }

        private static bool CheckGrant(IGrant grant, string code, int level)
        {
            if (level > 10)
            {
                throw new Exception("The depth of the included grants was deeper then 10 levels. Possible circular reference");
            }
            if (String.Equals(grant.Id, code, StringComparison.CurrentCultureIgnoreCase))
            {
                return true;
            }
            var newLevel = level + 1;
            return grant.IncludedGrants != null && grant.IncludedGrants.Any(g => CheckGrant(g, code, newLevel));
        }
    }
}
