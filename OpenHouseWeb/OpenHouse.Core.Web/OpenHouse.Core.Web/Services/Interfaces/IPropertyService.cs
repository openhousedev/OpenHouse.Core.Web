using OpenHouse.Model.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OpenHouse.Core.Services.Interfaces
{
    public interface IPropertyService
    {
        Task<property> GetPropertyAsync(int propertyId);
        Task<vwproperty> GetPropertyViewAsync(int id);
        Task<List<vwproperty>> GetPropertiesAsync(string searchString);
        Task<int> AddPropertyAsync(property property);
        Task<int> UpdatePropertyAsync(property property);
        Task<List<propertyclass>> GetPropertyClassesAsync();
        Task<List<propertytype>> GetPropertyTypesAsync();
        Task<bool> PropertyExistsAsync(int id);
    }
}

