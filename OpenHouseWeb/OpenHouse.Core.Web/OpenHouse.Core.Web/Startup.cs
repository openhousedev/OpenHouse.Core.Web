using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OpenHouse.Core.Services;
using OpenHouse.Core.Services.Interfaces;
using OpenHouse.Core.Web.Services.Interfaces;
using OpenHouse.Model.Core.Model;
using Microsoft.AspNetCore.DataProtection;
using System.IO;
using Microsoft.Extensions.Options;

namespace OpenHouse.Core.Web
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
            services.AddControllersWithViews();
            services.AddDbContext<OpenhouseContext>();

            services.AddScoped<IPropertyService, PropertyService>();
            services.AddScoped<ITenancyService, TenancyService>();
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IActionService, ActionService>();

            //services.AddDataProtection()
            //        .PersistKeysToFileSystem(new DirectoryInfo(@"C:\UNIAPPS\OpenHouse\OpenHouseAuthStore"))
            //        .SetApplicationName("OpenHouseSSO");

            //services.AddAuthentication("Identity.Application")
            //       .AddCookie("Identity.Application", option => {
            //           option.Cookie.Name = ".AspNet.OpenHouseSSO";
            //           option.Events.OnRedirectToLogin = (context) =>
            //           {
            //               //context.RedirectUri = "https://localhost:44365/Identity/Account/Login";
            //               return Task.CompletedTask;
            //           };
            //       });

            //services.ConfigureApplicationCookie(options =>
            //{
            //    options.Cookie.Name = ".AspNet.OpenHouseSSO";
            //    options.Cookie.Path = "/";
            //    options.Cookie.Domain = "localhost";
            //    //options.LoginPath = "https://localhost:44365/Identity/Account/Login";
            //    //options.LogoutPath = "https://localhost:44365/Identity/Account/Logout";
            //});

            //services.ConfigureApplicationCookie(options =>
            //{
            //    options.Cookie.Name = ".AspNet.OpenHouseSSO";
            //    options.Cookie.Path = "/";
            //    options.LoginPath = "https://localhost:44365/Identity/Account/Login";
            //    options.LogoutPath = "https://localhost:44365/Identity/Account/Logout";
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
