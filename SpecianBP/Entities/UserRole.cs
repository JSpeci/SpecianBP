using SpecianBP.DataProtection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SpecianBP.Entities
{
    public class UserRole : SoftDeletableEntity
    {
        //public List<UserUserRole> Users { get; set; } = new List<UserUserRole>();
        public string Name { get; set; }
        public string GrantsSerialized { get; set; }

        [NotMapped]
        public List<string> GrantIds
        {
            get => CommaSeparatedListConvert.FromCommaSeparatedString(GrantsSerialized);
            set => GrantsSerialized = CommaSeparatedListConvert.ToCommaSeparatedString(value?.Distinct());
        }
    }
}
