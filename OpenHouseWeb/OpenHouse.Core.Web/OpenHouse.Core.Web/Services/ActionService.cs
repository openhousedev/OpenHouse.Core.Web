﻿using Microsoft.EntityFrameworkCore;
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

        public async Task<int> CreateActionAsyc(action action)
        {
            _context.action.Add(action);
            return await _context.SaveChangesAsync();
        }

        public async Task<action> GetActionAsync(int actionId)
        {
            //var action 
            throw new NotImplementedException();
        }

        public async Task<List<vwaction>> GetActionsForTenancy(int tenancyId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<vwaction>> GetOpenActionsForUserAsync(int userId)
        {
            var actions = await _context.vwaction.Where(a => a.assignedUserId == userId && a.actionCompletedDate == null).ToListAsync();

            return actions;
        }

        public async Task<int> UpdateActionAsync(action action)
        {
            throw new NotImplementedException();
        }
    }
}