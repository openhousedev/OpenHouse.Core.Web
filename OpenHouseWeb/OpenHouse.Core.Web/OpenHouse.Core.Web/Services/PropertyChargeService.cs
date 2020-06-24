using Microsoft.EntityFrameworkCore;
using OpenHouse.Core.Web.Services.Interfaces;
using OpenHouse.Model.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace OpenHouse.Core.Web.Services
{
    public class PropertyChargeService : IPropertyChargeService
    {
        private readonly OpenhouseContext _context;
        public PropertyChargeService(OpenhouseContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get all active property charges for given property
        /// </summary>
        /// <param name="propertyId"></param>
        /// <returns>List of propertycharge object</returns>
        public async Task<List<propertycharge>> GetActivePropertyChargesAsync(int propertyId)
        {
            var charges = await _context.propertycharge
                                        .Where(c => c.propertyId == propertyId
                                              && c.startDT < DateTime.Now
                                              && (c.endDT == null || c.endDT > DateTime.Now)).ToListAsync();

            return charges;
                                  
        }
    }
}
