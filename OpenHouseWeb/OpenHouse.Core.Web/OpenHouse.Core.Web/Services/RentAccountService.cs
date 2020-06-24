using Microsoft.EntityFrameworkCore;
using OpenHouse.Core.Web.Services.Interfaces;
using OpenHouse.Model.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenHouse.Core.Services
{
    public class RentAccountService : IRentAccountService
    {
        private readonly OpenhouseContext _context;
        public RentAccountService(OpenhouseContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get all rent accounts
        /// </summary>
        /// <returns>List of rent accounts</returns>
        public async Task<List<rentaccount>> GetRentAccountsAsync()
        {
            return await _context.rentaccount.ToListAsync();
        }

        /// <summary>
        /// Retrieves rent ledger records for property
        /// </summary>
        /// <param name="tenancyId"></param>
        /// <returns>List from vwRentLedger</returns>
        public async Task<List<vwrentledger>> GetRentLedgerForTenancyAsync(int tenancyId)
        {
            return await _context.vwrentledger.Where(r => r.tenancyId == tenancyId).ToListAsync();
        }

        /// <summary>
        /// Retrieves all available payment sources
        /// </summary>
        /// <returns></returns>
        public async Task<List<paymentsource>> GetPaymentSourcesAsync()
        {
            return await _context.paymentsource.ToListAsync();
        }
    }
}
