using OpenHouse.Model.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenHouse.Core.Web.Services.Interfaces
{
    public interface IPersonService
    {
        public Task<person> GetPersonAsync(int personId);
        public Task<List<vwperson>> GetPersonsAsync(string searchString);
        public Task<int> AddPersonsAsync(person person);
        public Task<int> UpdatePersonsAsync(person person);
        public Task<List<nationality>> GetNationalitiesAsync();
        public Task<List<title>> GetTitlesAsync();
        public Task<int> DeletePersonAsync(int personId);
        public Task<bool> PersonExistsAsync(int personId);
    }
}
