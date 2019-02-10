using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Template.Authorization.Users;
using Template.Core;

namespace Template.Authorization.Roles
{
    public class UserRoles : Entity<long>
    {
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
        public long UserId { get; set; }

        [ForeignKey(nameof(RoleId))]
        public Role Role { get; set; }
        public int RoleId { get; set; }
    }
}
