using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OpenHouse.Core.Services.Interfaces;
using OpenHouse.Core.Web.Models;
using OpenHouse.Model.Core.Model;

namespace OpenHouse.Core.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPropertyService _propertySvc;
        private readonly ITenancyService _tenancySvc;

        public HomeController(ILogger<HomeController> logger, IPropertyService propertySvc, ITenancyService tenancySvc)
        {
            _logger = logger;
            _propertySvc = propertySvc;
            _tenancySvc = tenancySvc;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> _PropertySearch(string searchString)
        {
            var properties = await _propertySvc.GetPropertiesAsync(searchString);

            return PartialView(properties);
        }

        public async Task<IActionResult> _TenancySearch(string searchString)
        {
            var tenancies = await _tenancySvc.GetTenanciesAsync(searchString);

            return PartialView(tenancies);
        }
    }
}
