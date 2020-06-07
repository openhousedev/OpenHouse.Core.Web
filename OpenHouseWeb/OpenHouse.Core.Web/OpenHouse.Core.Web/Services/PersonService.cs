using Microsoft.EntityFrameworkCore;
using OpenHouse.Core.Services.Interfaces;
using OpenHouse.Core.Web.Services.Interfaces;
using OpenHouse.Model.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenHouse.Core.Services
{
    public class PersonService : IPersonService
    {
        private readonly OpenhouseContext _context;

        public PersonService(OpenhouseContext context)
        {
            _context = context;
        }

        public async Task<int> AddPersonsAsync(person person)
        {
            _context.person.Add(person);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeletePersonAsync(int personId)
        {
            var person = _context.person.Find(personId);
            _context.Remove(person);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<nationality>> GetNationalitiesAsync()
        {
            return await _context.nationality.ToListAsync();
        }

        public async Task<person> GetPersonAsync(int personId)
        {
            var person = await _context.person
                                         .Include(p => p.nationality)
                                         .Include(p => p.title)
                                         .FirstOrDefaultAsync(m => m.personId == personId);
            return person;
        }

        public async Task<List<vwperson>> GetPersonsAsync(string searchString)
        {
            var persons = await _context.vwperson.Where(p => p.fullName.ToLower().Contains(searchString.ToLower()) || p.personId.ToString() == searchString).ToListAsync();

            return persons;
        }

        public async Task<List<title>> GetTitlesAsync()
        {
            return await _context.title.ToListAsync();
        }

        public async Task<bool> PersonExistsAsync(int personId)
        {
            return await _context.person.AnyAsync(e => e.personId == personId);
        }

        public async Task<int> UpdatePersonsAsync(person person)
        {
            _context.person.Update(person);
            return await _context.SaveChangesAsync();
        }
    }
}
