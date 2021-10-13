using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SazMart.DAL.ModelClass.DTO;
using SazMart.DAL.ModelClass.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SazMart.Service.Controllers
{
    [Route("api/Security")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly UserManager<AppUser> _manager;
        private readonly IMapper _mapper;

        public SecurityController(UserManager<AppUser> manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        [HttpPost("AddUser")]
        public async Task<ActionResult<AppUserDTO>> AddUser(AppUserDTO appUserDTO)
        {

            if (await IsExist(appUserDTO.Email)) return BadRequest("Email Already Exits");

            appUserDTO.CreatedBy = "Bappy";
            appUserDTO.CreatedDate = DateTime.Now;
            appUserDTO.Status = (int)SazMart.Common.Enum.Enum.Status.Active;
            var user = _mapper.Map<AppUser>(appUserDTO);
            user.Email = appUserDTO.Email.ToLower();
            user.UserName = appUserDTO.UserName.ToLower();
            var result = await _manager.CreateAsync(user, appUserDTO.Password);
            if (!result.Succeeded) return BadRequest(result.Errors);
            return appUserDTO;

        }












        private async Task<bool> IsExist(string Email)
        {
            return await _manager.Users.AnyAsync(x => x.Email == Email);
        }
    }
}
