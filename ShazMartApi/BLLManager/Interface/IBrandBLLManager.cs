using SazMart.DAL.ModelClass.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLManager.Interface
{
    public interface IBrandBLLManager
    {
        Task<Guid> Upsert(BrandViewModel model);
        Task<bool> SaveChangeAll();
        Task<bool> IsExits(string brandName);
    }
}
