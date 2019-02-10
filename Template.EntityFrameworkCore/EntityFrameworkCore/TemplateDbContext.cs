using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Template.Authorization.Roles;
using Template.Authorization.Users;

namespace Template.EntityFrameworkCore
{
    public class TemplateDbContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<UserRoles> UserRoles { get; set; }

        public TemplateDbContext(DbContextOptions<TemplateDbContext> options)
            : base(options)
        { } 
    }
}
