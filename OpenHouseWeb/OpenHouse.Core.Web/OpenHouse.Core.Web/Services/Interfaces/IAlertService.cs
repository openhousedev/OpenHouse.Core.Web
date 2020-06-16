using OpenHouse.Model.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenHouse.Core.Services.Interfaces
{
    public interface IAlertService
    {
        public Task<List<vwalert>> GetAlertsForTenancyAsync(int tenancyId);
        public Task<List<alerttype>> GetAlertTypesAsync();
    }
}
