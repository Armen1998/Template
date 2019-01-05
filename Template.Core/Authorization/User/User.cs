using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Template.Core.Authorization.User
{
    public class User : Entity<long>
    {
        public const int UserNameMaxLength = 32;
        public const int PasswordMaxLength = 64;
        public const int EmailMaxLength = 256;
        public const int FullNameMaxLength = 256;
        
        [Required]
        [MaxLength(UserNameMaxLength)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(PasswordMaxLength)]
        public string Password { get; set; }
        [Required]
        [MaxLength(EmailMaxLength)]
        public string Email { get; set; }
        [MaxLength(FullNameMaxLength)]
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
