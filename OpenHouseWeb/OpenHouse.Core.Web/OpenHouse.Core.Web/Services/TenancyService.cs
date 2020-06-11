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

        /// <summary>
        /// Creates new tenancy
        /// </summary>
        /// <param name="tenancy">Tenancy Object</param>
        /// <returns>New tenancy ID</returns>
        public async Task<int> AddTenancyAsync(tenancy tenancy)
        {
            _context.tenancy.Add(tenancy);
            await _context.SaveChangesAsync();

            return tenancy.tenancyId;
        }

        /// <summary>
        /// Update existing tenancy record
        /// </summary>
        /// <param name="tenancy"></param>
        /// <returns></returns>
        public async Task<int> UpdateTenancyAsync(tenancy tenancy)
        {
            _context.tenancy.Update(tenancy);
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Get list of tenancies based on search string
        /// </summary>
        /// <param name="searchString">Lead tenant, address or tenancy ID filter</param>
        /// <returns></returns>
        public async Task<List<vwtenancy>> GetTenanciesAsync(string searchString)
        {
            var tenancies = await _context.vwtenancy
                                          .Where(t => (t.tenancyId.ToString() == searchString 
                                                    || t.leadTenant.ToLower().Contains(searchString.ToLower())))
                                          .OrderBy(t => t.tenancyId)
                                          .Distinct()
                                          .ToListAsync();

            return tenancies;
        }

        /// <summary>
        /// Get full tenancy history for property
        /// </summary>
        /// <param name="propertyId"></param>
        /// <returns></returns>
        public async Task<List<vwtenancy>> GetTenanciesForPropertyIdAsync(int propertyId)
        {
            var tenancies = await _context.vwtenancy
                              .Where(t => t.propertyId == propertyId)
                              .OrderByDescending(t => t.startDate)
                              .ToListAsync();

            return tenancies;
        }

        /// <summary>
        /// Gets individual tenancy
        /// </summary>
        /// <param name="tenancyId"></param>
        /// <returns></returns>
        public async Task<tenancy> GetTenancyAsync(int tenancyId)
        {
            var tenancy = await _context.tenancy
                        .Include(t => t.jointTenantPerson)
                        .Include(t => t.leadTenantPerson)
                        .Include(t => t.tenureType)
                        .Include(t => t.tenancyhousehold)
                        .FirstOrDefaultAsync(m => m.tenancyId == tenancyId);

            return tenancy;
        }

        /// <summary>
        /// Gets all household members for tenancy
        /// </summary>
        /// <param name="tenancyId"></param>
        /// <returns></returns>
        public async Task<List<tenancyhousehold>> GetTenancyHouseholdAsync(int tenancyId)
        {
            var tenancyHousehold = await _context.tenancyhousehold
                                    .Where(t => t.tenancyId == tenancyId)
                                    .Include(t => t.person)
                                    .Include(t => t.jointTenantRelationship)
                                    .Include(t => t.leadTenantRelationship)
                                    .ToListAsync();

            return tenancyHousehold;                                                                    
        }

        /// <summary>
        /// Gets all tenure types
        /// </summary>
        /// <returns></returns>
        public async Task<List<tenuretype>> GetTenuretypesAsync()
        {
            var tenureTypes = await _context.tenuretype.ToListAsync();
            return tenureTypes;
        }

        /// <summary>
        /// Returns all tenancy termination reasons
        /// </summary>
        /// <returns></returns>
        public async Task<List<tenancyterminationreason>> GetTenancyterminationreasonsAsync()
        {
            var termindationReasons = await _context.tenancyterminationreason.ToListAsync();
            return termindationReasons;
        }

    }
}
