using SazMart.DAL.ModelClass.DTO;
using SazMart.DAL.ModelClass.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLManager.Interface
{
    public interface IUserBLLManager
    {
        Task<AppUser> AddUserAsync(AppUser appUser);
        Task<IEnumerable<UserDTO>> GetAllUserAsync();
        Task<UserDTO> GetMemberNameByAsync(string userName);
        Task<AppUser> GetUserNameByAsync(string userName);
        Task<bool> SaveChangeAllAsync();
        Task<bool> IsUserExist(string userName);
    }
}
