using OpenHouse.Model.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenHouse.Core.Web.Services.Interfaces
{
    public interface INoteService
    {
        public Task<List<note>> GetNotesForPropertyAsync(int propertyId);
        public Task<List<note>> GetNotesForTenancyAsync(int tenancyId);
    }
}
