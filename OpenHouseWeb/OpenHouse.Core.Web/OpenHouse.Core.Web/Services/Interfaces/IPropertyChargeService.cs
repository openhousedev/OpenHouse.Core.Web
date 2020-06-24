using OpenHouse.Model.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenHouse.Core.Web.Services.Interfaces
{
    public interface IPropertyChargeService
    {
        public Task<List<propertycharge>> GetActivePropertyChargesAsync(int propertyId);
    }
}
