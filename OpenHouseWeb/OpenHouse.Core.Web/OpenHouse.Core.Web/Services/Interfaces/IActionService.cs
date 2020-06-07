using OpenHouse.Model.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenHouse.Core.Services.Interfaces
{
    public interface IActionService
    {
        public Task<List<vwaction>> GetOpenActionsForUserAsync(int userId);
        public Task<List<vwaction>> GetActionsForTenancy(int tenancyId);
        public Task<int> CreateActionAsyc(action action);
        public Task<int> UpdateActionAsync(action action);
        public Task<action> GetActionAsync(int actionId);
    }
}
