using SazMart.DAL.ModelClass.DTO;
using SazMart.DAL.ModelClass.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLManager.Interface
{
    public interface ICityBLLManager
    {
        Task<City> AddCityAsync(City city);
        Task<IEnumerable<CityDTO>> GetAll();
        Task<bool> SaveAllAsync();
        Task<bool> IsExists(string cityName);
    }
}
