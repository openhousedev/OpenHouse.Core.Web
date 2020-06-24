using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenHouse.Core.Web.Areas.Identity.Data;
using OpenHouse.Core.Web.Data;

[assembly: HostingStartup(typeof(OpenHouse.Core.Web.Areas.Identity.IdentityHostingStartup))]
namespace OpenHouse.Core.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public IdentityHostingStartup(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddDbContext<IdentityContext>(options =>
                    options.UseMySql(
                        context.Configuration.GetConnectionString("IdentityContextConnection")));



            });
        }
    }
}