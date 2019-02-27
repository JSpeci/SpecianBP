using SpecianBP.DataProtection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SpecianBP.Entities
{
    public class User : SoftDeletableEntity, IGrantsHolder
    {
        public string DisplayName { get; set; }
        public string UserName { get; set; }

        public bool IsAdmin { get; set; }
        public string IdentityId { get; set; }

        [NotMapped]
        public string Password { get; set; }

        public bool HasGrant(IGrant grant)
        {
            return IsAdmin || GrantsHolderExtensions.HasGrant(this, grant);
        }

        public List<UserUserRole> UserRoles { get; set; } = new List<UserUserRole>();

        private List<IGrant> _grants;

        [NotMapped]
        //[DependentInclude(nameof(UserRoles))]
        public IEnumerable<IGrant> Grants
        {
            get
            {
                if (_grants == null)
                {
                    var grantIds = UserRoles.SelectMany(x => x.UserRole.GrantIds).Distinct();
                    _grants = DataProtection.Grants.GetGrants(grantIds).ToList();
                }
                return _grants;
            }
        }
    }
}
