using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using OneUnit.Services;
using OneUnit.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using AutoMapper;
using OneUnit.Areas.QC.Data;
using OneUnit.Data.Entities;
using Microsoft.AspNetCore.Identity;
using OneUnit.Areas.Admin.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using OneUnit.Areas.Transit.Data;

namespace OneUnit
{
    public class Startup
    {
        private readonly IConfiguration _config;
        private readonly IHostingEnvironment _env;

        public Startup(IConfiguration config,IHostingEnvironment env)
        {
            _config = config;
            _env = env;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentity<StoreUser, IdentityRole>(cfg=>
            {
                cfg.User.RequireUniqueEmail = false;
                cfg.Password.RequiredLength = 8;
                cfg.Password.RequireNonAlphanumeric = true;
                cfg.Password.RequireUppercase = true;
               
            })
            .AddEntityFrameworkStores<OneUnitContext>().AddDefaultTokenProviders();
            services.AddDbContext<OneUnitContext>(cfg=> 
            {
                cfg.UseSqlServer(_config.GetConnectionString("OneUnitConnectionString"));
            });
            services.AddAutoMapper();
            services.AddTransient<IMailService, NullMailService>();
            //Support for real mail service
            services.AddTransient<OneUnitSeeder>();
            services.AddScoped<IOneUnitRepository, OneUnitRepository>();
            services.AddScoped<IQCRepository, QCRepository>();
            services.AddScoped<ITransitRepository, TransitRepository>();
            services.AddMvc(opt=>
            {
                if (_env.IsProduction())
                {
                    opt.Filters.Add(new RequireHttpsAttribute());
                }
            })
                .AddJsonOptions(opt=>opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
            // services.ConfigureApplicationCookie(options => options.LoginPath = "/Admin/Account/Login");

            //Claims-based
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdministratorOnly", policy => policy.RequireRole("Administrator"));
                options.AddPolicy("DeleteProcessName", policy => policy.RequireClaim("Delete ProcessName", "Delete ProcessName"));
                options.AddPolicy("AddProcessName", policy => policy.RequireClaim("Add ProcessName", "Add ProcessName"));
                options.AddPolicy("AddProcessName1", policy => policy.RequireClaim("Add ProcessName1", "Add ProcessName1"));
                options.AddPolicy("MinimumOrderAge", policy => policy.Requirements.Add(new MinimumOrderAgeRequirement(18)));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
         if(env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
            }


            //app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseAuthentication();
             // app.UseMvc(cfg =>
           //  {
             //   cfg.MapRoute("Default",
             // "{area=QC}/{controller}/{action}/{id?}", 
            // new { controller = "QC", Action = "Index" });
            //-----------------------------------------------------------
            //    cfg.MapRoute("Default",
            // "{controller}/{action}/{id?}",
            //  new { controller = "App", Action = "Index" });
            //-----------------------------------------------------------

           // });
            app.UseMvc(routes =>
            {
                routes.MapRoute("areaRoute", "{area:exists}/{controller=Account}/{action=Login}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=App}/{action=Index}/{id?}");
            });
            if (env.IsDevelopment())
            {
                //seed the database
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var seeder = scope.ServiceProvider.GetService<OneUnitSeeder>();
                    seeder.Seed().Wait();
                }
            }
        }
    }
}
