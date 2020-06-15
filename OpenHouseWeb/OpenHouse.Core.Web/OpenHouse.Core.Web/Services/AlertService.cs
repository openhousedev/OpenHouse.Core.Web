using Microsoft.EntityFrameworkCore;
using OpenHouse.Core.Services.Interfaces;
using OpenHouse.Core.Web.Services.Interfaces;
using OpenHouse.Model.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenHouse.Core.Web.Services
{
    public class AlertService : IAlertService
    {
        private readonly OpenhouseContext _context;
        public AlertService(OpenhouseContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets list of alerts in alert view for given tenancy ID
        /// </summary>
        /// <param name="tenancyId"></param>
        /// <returns></returns>
        public async Task<List<vwalert>> GetAlertsForTenancyAsync(int tenancyId)
        {
            var alerts = await _context.vwalert.Where(t => t.tenancyId == tenancyId).ToListAsync();

            return alerts;
        }
    }
}
