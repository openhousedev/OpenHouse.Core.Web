using Microsoft.EntityFrameworkCore;
using OpenHouse.Core.Services.Interfaces;
using OpenHouse.Model.Core.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenHouse.Core.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly OpenhouseContext _context;
        public PropertyService(OpenhouseContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Add new property
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public async Task<int> AddPropertyAsync(property property)
        {
            _context.Add(@property);
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Update existing property
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public async Task<int> UpdatePropertyAsync(property property)
        {
            _context.Update(@property);
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Query list of properties
        /// </summary>
        /// <param name="address"></param>
        /// <param name="areadId"></param>
        /// <returns></returns>
        public async Task<List<vwproperty>> GetPropertiesAsync(string searchString)
        {
            var properties = await _context.vwproperty
                                            .Where(p => (p.contactAddress.ToLower().Contains(searchString.ToLower()) || p.propertyId.ToString() == searchString))
                                            .OrderBy(p => p.contactAddress)
                                            .Distinct()
                                            .ToListAsync();

            return properties;
        }

        /// <summary>
        /// Get property by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<property> GetPropertyAsync(int id)
        {
            var property = await _context.property
                                        .Include(p => p.propertynote)
                                            .ThenInclude(p => p.note)
                                        .Include(p => p.propertyClass)
                                        .Include(p => p.propertyType)
                                        .FirstOrDefaultAsync(m => m.propertyId == id);
            return property;
        }

        /// <summary>
        /// Get vwProperty object from property ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<vwproperty> GetPropertyViewAsync(int id)
        {
            var propertyView = await _context.vwproperty
                                            .Where(p => p.propertyId == id)
                                            .FirstOrDefaultAsync();

            return propertyView;
        }

        /// <summary>
        /// Get all available property classes
        /// </summary>
        /// <returns></returns>
        public async Task<List<propertyclass>> GetPropertyClassesAsync()
        {
            var classes = await _context.propertyclass.ToListAsync();
            return classes;
        }

        /// <summary>
        /// Get all available property types
        /// </summary>
        /// <returns></returns>
        public async Task<List<propertytype>> GetPropertyTypesAsync()
        {
            var types = await _context.propertytype.ToListAsync();
            return types;
        }

        /// <summary>
        /// Check if property ID is valid
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> PropertyExistsAsync(int id)
        {
            return await _context.property.AnyAsync(e => e.propertyId == id);
        }
    }
}
