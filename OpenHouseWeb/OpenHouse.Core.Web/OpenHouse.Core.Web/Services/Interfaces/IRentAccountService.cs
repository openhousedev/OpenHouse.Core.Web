using OpenHouse.Model.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenHouse.Core.Web.Services.Interfaces
{
    public interface IRentAccountService
    {
        public Task<List<rentaccount>> GetRentAccountsAsync();
        public Task<List<vwrentledger>> GetRentLedgerForTenancyAsync(int tenancyId);
        public Task<List<paymentsource>> GetPaymentSourcesAsync();
    }
}
