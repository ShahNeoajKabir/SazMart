using SazMart.DAL.ModelClass.DTO;
using SazMart.DAL.ModelClass.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLManager.Interface
{
    public interface IProductBLLManager
    {
        Task<Product> AddProductAsync(Product product);
        Task<IEnumerable<ProductDTO>> GetAllProduct();
        Task<bool> SaveAllAsync();
    }
}
