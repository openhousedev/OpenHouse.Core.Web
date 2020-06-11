using OpenHouse.Model.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenHouse.Core.Services.Interfaces
{
    public interface ITenancyService
    {
        public Task<tenancy> GetTenancyAsync(int tenancyId);
        public Task<List<vwtenancy>> GetTenanciesAsync(string searchString);
        public Task<List<vwtenancy>> GetTenanciesForPropertyIdAsync(int propertyId);
        public Task<int> AddTenancyAsync(tenancy tenancy);
        public Task<int> UpdateTenancyAsync(tenancy tenancy);
        public Task<List<tenuretype>> GetTenuretypesAsync();
        public Task<List<tenancyhousehold>> GetTenancyHouseholdAsync(int tenancyId);
        public Task<List<tenancyterminationreason>> GetTenancyterminationreasonsAsync();
    }
}
