using OpenHouse.Model.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenHouse.Core.Services.Interfaces
{
    public interface ITenancyService
    {
        public Task<tenancy> GetTenancyAsync(int propertyId);
        public Task<List<vwtenancy>> GetTenanciesAsync(string searchString);
        public Task<int> AddTenancyAsync(tenancy property);
        public Task<tenancy> UpdateTenancyAsync(tenancy property);
    }
}
