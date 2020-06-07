using Microsoft.EntityFrameworkCore;
using OpenHouse.Core.Services.Interfaces;
using OpenHouse.Model.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenHouse.Core.Services
{
    public class TenancyService : ITenancyService
    {
        private readonly OpenhouseContext _context;

        public TenancyService(OpenhouseContext context)
        {
            _context = context;
        }

        public async Task<int> AddTenancyAsync(tenancy property)
        {
            throw new NotImplementedException();
        }

        public async Task<List<vwtenancy>> GetTenanciesAsync(string searchString)
        {
            var tenancies = await _context.vwtenancy
                                          .Where(t => (t.tenancyId.ToString() == searchString 
                                                    || t.leadTenant.ToLower().Contains(searchString.ToLower())))
                                          .OrderBy(t => t.tenancyId)
                                          .ToListAsync();

            return tenancies;
        }

        public async Task<tenancy> GetTenancyAsync(int propertyId)
        {
            throw new NotImplementedException();
        }

        public async Task<tenancy> UpdateTenancyAsync(tenancy property)
        {
            throw new NotImplementedException();
        }
    }
}
