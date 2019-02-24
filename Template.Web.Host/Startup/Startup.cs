using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Template.Authorization.Roles;
using Template.Authorization.Users;
using Template.Core.Repositories;
using Template.EntityFrameworkCore;
using Template.EntityFrameworkCore.Repositories;
using Template.Web.Host.Extensions;

namespace Template.Web.Host
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddApplicationPart(Assembly.Load(new AssemblyName("Template.Application")));

            services.AddDbContext<TemplateDbContext>(opts =>
                opts.UseNpgsql(Configuration.GetConnectionString("Postgresql")));

            //services.AddDbContext<TemplateDbContext>(opts =>
            //    opts.UseSqlServer(Configuration.GetConnectionString("SqlServer")));

            services.AddTransient<IRepository<User, long>, Repository<User, long>>();
            services.AddTransient<IRepository<UserRoles, long>, Repository<UserRoles, long>>();
            services.AddTransient<IRepository<Role>, Repository<Role>>();            

            services.RegisterServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc();

        }
    }
}
