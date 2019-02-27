using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpecianBP.Entities
{
    public class UserUserRole : Entity
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid UserRoleId { get; set; }
        public UserRole UserRole { get; set; }
    }
}
