using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Template.Core.Configuration;
using Template.EntityFrameworkCore;
using Template.EntityFrameworkCore.EntityFrameworkCore.Seed;
using Template.Shared.Extensions.Reflection;

namespace Template.Migrator
{
    class Program
    {
        public static void Main(string[] args)
        {
            var service = new ServiceCollection();
            var _configuration = AppConfiguration.Get(
                 typeof(Program).GetAssembly().GetDirectoryPathOrNull()
                );

            service.AddDbContext<TemplateDbContext>(opts =>
               opts.UseNpgsql(_configuration.GetConnectionString("Default")));

            service.AddSingleton<TemplateDbContext>();

            var context = service
                .BuildServiceProvider()
                .GetService<TemplateDbContext>();

            SeedHelper.SeedDb(context);
        }
    }
}
