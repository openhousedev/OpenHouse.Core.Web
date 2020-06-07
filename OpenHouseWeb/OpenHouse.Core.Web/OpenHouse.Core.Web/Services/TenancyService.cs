﻿using Microsoft.EntityFrameworkCore;
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

        public async Task<int> AddTenancyAsync(tenancy tenancy)
        {
            _context.tenancy.Add(tenancy);
            return await _context.SaveChangesAsync();
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

        public async Task<tenancy> GetTenancyAsync(int tenancyId)
        {
            var tenancy = await _context.tenancy
                        .Include(t => t.jointTenantPerson)
                        .Include(t => t.leadTenantPerson)
                        .Include(t => t.tenureType)
                        .FirstOrDefaultAsync(m => m.tenancyId == tenancyId);

            return tenancy;
        }

        public async Task<List<tenuretype>> GetTenuretypesAsync()
        {
            var tenureTypes = await _context.tenuretype.ToListAsync();
            return tenureTypes;
        }

        public async Task<int> UpdateTenancyAsync(tenancy tenancy)
        {
            _context.Add(tenancy);
            return await _context.SaveChangesAsync();
        }
    }
}
