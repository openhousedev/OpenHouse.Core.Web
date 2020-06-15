using OpenHouse.Model.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenHouse.Core.Services.Interfaces
{
    public interface IActionService
    {
        public Task<List<vwaction>> GetOpenActionsForUserAsync(string userId);
        public Task<List<vwaction>> GetActionsForTenancyAsync(int tenancyId);
        public Task<int> CreateActionAsyc(action action);
        public Task<action> GetActionAsync(int actionId);
        public Task<List<actiontype>> GetActionTypesAsync();
    }
}
