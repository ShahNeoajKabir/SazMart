using SazMart.DAL.ModelClass.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLManager.Interface
{
    public interface IColorBLLManager
    {
        Task<ColorDTO> AddColor(ColorDTO colorDTO);
        Task<IEnumerable<ColorDTO>> GetAll();
        Task<bool> SaveAllAsync();
    }
}
