using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace OpenHouse.Core.Web.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the User class
    public class ApplicationUser : IdentityUser
    {
        public string firstName { get; set; }
        public string surname { get; set; }
        public string telephone { get; set; }
    }
}
