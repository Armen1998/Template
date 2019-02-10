using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Template.Core.Authorization.Roles
{
    public class Role : Entity
    {
        public const int NameMaxLength = 64;
        public const int DisplayNameMaxLength = 64;

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }
        [Required]
        [MaxLength(DisplayNameMaxLength)]
        public string DisplayName { get; set; }
    }
}
