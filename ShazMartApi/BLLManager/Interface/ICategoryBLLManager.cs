using SazMart.DAL.ModelClass.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLManager.Interface
{
    public interface ICategoryBLLManager
    {
        Task<Guid> Upsert(CategoryViewModel viewModel);
        Task<IEnumerable<CategoryViewModel>> GetAllActiveCategory();
        Task<IEnumerable<CategoryViewModel>> GetAllDeactiveCategory();
        List<CategoryViewModel> GetAll();
        Task<CategoryViewModel> GetById(Guid Id);
        Task<bool> DeleteCategory(Guid Id);
    }
}
