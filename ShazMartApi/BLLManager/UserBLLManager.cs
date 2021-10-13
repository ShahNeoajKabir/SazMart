using AutoMapper;
using AutoMapper.QueryableExtensions;
using BLLManager.Interface;
using Microsoft.EntityFrameworkCore;
using SazMart.DAL.Database;
using SazMart.DAL.ModelClass.DTO;
using SazMart.DAL.ModelClass.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLManager
{
    public class UserBLLManager : IUserBLLManager
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public UserBLLManager(DatabaseContext context ,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AppUser> AddUserAsync(AppUser appUser)
        {
            appUser.CreatedBy = "Bappy";
            appUser.CreatedDate = DateTime.Now;
            appUser.Status = (int)SazMart.Common.Enum.Enum.Status.Active;
            await _context.Users.AddAsync(appUser);
            return appUser;
        }

        public async Task<IEnumerable<UserDTO>> GetAllUserAsync()
        {
            return await _context.Users
                .ProjectTo<UserDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<UserDTO> GetMemberNameByAsync(string userName)
        {
            return await _context.Users.Where(p => p.UserName.ToLower() == userName.ToLower())
                .ProjectTo<UserDTO>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }

        public Task<AppUser> GetUserNameByAsync(string userName)
        {
            throw new NotImplementedException();
        }

        public  async Task<bool> IsUserExist(string enmail)
        {
            return await _context.Users.AnyAsync(x => x.Email == enmail);
        }

        public async Task<bool> SaveChangeAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
