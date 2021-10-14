using SazMart.DAL.ModelClass.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLLManager.Interface
{
    public interface IBrandBLLManager
    {
        Task<Brand> AddBrandAsync(Brand brand);
        Task<IEnumerable<Brand>> GetAll();
        Task<bool> SaveAllAsync();
        Task<bool> IsExits(string brandName);
    }
}
