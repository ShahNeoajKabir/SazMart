using SazMart.DAL.ModelClass.DTO;
using SazMart.DAL.ModelClass.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLManager.Interface
{
    public interface ICategoriesBLLManager
    {
        Task<Categories> AddCategoriesAsync(Categories categories);
        Task<IEnumerable<CategoriesDTO>> GetCategories();
        Task<CategoriesDTO> GetCategoriesByName(string categoriesname);
        Task< SubCategories> AddSubCategoriesByAsync(SubCategories subCategories);
        Task< bool> SaveAllAsync();
        Task< bool> IsExits(string categoriesName);
    }
}
