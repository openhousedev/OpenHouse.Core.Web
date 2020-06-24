using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OpenHouse.Core.Services;
using OpenHouse.Core.Services.Interfaces;
using OpenHouse.Core.Web.Services.Interfaces;
using OpenHouse.Model.Core.Model;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Identity;
using OpenHouse.Core.Web.Areas.Identity.Data;
using System.Threading.Tasks;
using OpenHouse.Core.Web.Data;
using System;
using Microsoft.EntityFrameworkCore;

namespace OpenHouse.Core.Web
{
    public class Startup
    {
        private readonly string CorsPolicyName = "CorsPolicy";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: CorsPolicyName,
                                  builder =>
                                  {
                                      builder.AllowAnyOrigin();
                                      builder.AllowAnyMethod();
                                      builder.AllowAnyHeader();
                                  });
            });


            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddDbContext<OpenhouseContext>();
            services.AddDbContext<IdentityContext>(options =>
                    options.UseMySql(
                        Configuration.GetConnectionString("IdentityContextConnection")));

            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<IdentityContext>();

            services.AddScoped<IPropertyService, PropertyService>();
            services.AddScoped<ITenancyService, TenancyService>();
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IActionService, ActionService>();
            services.AddScoped<IAlertService, AlertService>();
            services.AddScoped<IRentAccountService, RentAccountService>();
            services.AddOData();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
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
            app.UseCors(CorsPolicyName);
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}")
                .RequireCors(CorsPolicyName);

                endpoints.MapRazorPages();
            });

            var task = Task.Run(async () => await SampleData.Initialize(serviceProvider));
        }

        //private async Task CreateRoles(IServiceProvider serviceProvider)
        //{
        //    //adding customs roles : Question 1
        //    var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        //    var UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        //    string[] roleNames = { "Admin", "ReadOnly", "HousingManager", "HousingUser" };
        //    IdentityResult roleResult;

        //    foreach (var roleName in roleNames)
        //    {
        //        var roleExist = await RoleManager.RoleExistsAsync(roleName);
        //        if (!roleExist)
        //        {
        //            //create the roles and seed them to the database: Question 2
        //            roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
        //        }
        //    }
        //}
    }
}
