using Microsoft.EntityFrameworkCore;
using OpenHouse.Core.Services.Interfaces;
using OpenHouse.Model.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenHouse.Core.Web.Services
{
    public class ActionService : IActionService
    {
        private readonly OpenhouseContext _context;
        public ActionService(OpenhouseContext context)
        {
            _context = context;
        }

        public Task<int> CreateActionAsyc(action action)
        {
            throw new NotImplementedException();
        }

        public Task<action> GetActionAsync(int actionId)
        {
            throw new NotImplementedException();
        }

        public Task<List<vwaction>> GetActionsForTenancy(int tenancyId)
        {
            throw new NotImplementedException();
        }

        public Task<List<vwaction>> GetOpenActionsForUserAsync(int userId)
        {
            var actions = await _context.vwaction.Where(a => a.assignedUserId == userId && a.actionCompletedDate == null).ToListAsync();

            return actions;
        }

        public Task<int> UpdateActionAsync(action action)
        {
            throw new NotImplementedException();
        }
    }
}
