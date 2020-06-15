using Microsoft.EntityFrameworkCore;
using OpenHouse.Core.Services.Interfaces;
using OpenHouse.Model.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenHouse.Core.Services
{
    public class ActionService : IActionService
    {
        private readonly OpenhouseContext _context;
        public ActionService(OpenhouseContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Create action in model
        /// </summary>
        /// <param name="action">Action object</param>
        /// <returns>Newly created action ID</returns>
        public async Task<int> CreateActionAsyc(action action)
        {
            _context.action.Add(action);
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Get action object from model
        /// </summary>
        /// <param name="actionId"></param>
        /// <returns>Action object iwth action type</returns>
        public async Task<action> GetActionAsync(int actionId)
        {
            var action = await _context.action.Include(a => a.actionType)
                                              .Where(a => a.actionId == actionId)
                                              .FirstOrDefaultAsync();
            return action;
        }

        /// <summary>
        /// Get actions for a given tenancyID
        /// </summary>
        /// <param name="tenancyId"></param>
        /// <returns>List of data from vwAction</returns>
        public async Task<List<vwaction>> GetActionsForTenancyAsync(int tenancyId)
        {
            var actions = await _context.vwaction.Where(a => a.tenancyId == tenancyId)
                                                 .ToListAsync();

            return actions;
        }

        /// <summary>
        /// Get list of action types
        /// </summary>
        /// <returns></returns>
        public async Task<List<actiontype>> GetActionTypesAsync()
        {
            var actionTypes = await _context.actiontype.ToListAsync();
            return actionTypes;
        }

        /// <summary>
        /// Get all outstanding actions for given user ID
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Lsit of data from vwAction</returns>
        public async Task<List<vwaction>> GetOpenActionsForUserAsync(string userId)
        {
            var actions = await _context.vwaction.Where(a => a.assignedUserId == userId 
                                                          && a.actionCompletedDate == null)
                                                 .ToListAsync();

            return actions;
        }
    }
}
