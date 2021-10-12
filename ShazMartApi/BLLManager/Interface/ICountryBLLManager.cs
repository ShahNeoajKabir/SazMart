using SazMart.DAL.ModelClass.DTO;
using SazMart.DAL.ModelClass.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLManager.Interface
{
    public interface ICountryBLLManager
    {
        Task<Country> AddCountryAsync(Country country);
        Task<IEnumerable<CountryDTO>> GetAllCountryAsync();
        Task<bool> SaveAllAsync();
        Task<bool> IsExists(string countryName);
    }
}
