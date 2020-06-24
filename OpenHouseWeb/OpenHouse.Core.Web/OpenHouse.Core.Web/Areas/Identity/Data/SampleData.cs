using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using OpenHouse.Core.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace OpenHouse.Core.Web.Areas.Identity.Data
{
    public class SampleData
    {
        public static async Task Initialize(IServiceProvider provider)
        {
            var userManager = provider.GetService<UserManager<ApplicationUser>>();
            var roleManager = provider.GetService<RoleManager<IdentityRole>>();

           

        }
    }
}
