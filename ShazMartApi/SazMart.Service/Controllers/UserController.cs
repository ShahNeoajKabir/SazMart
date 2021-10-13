using BLLManager.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SazMart.DAL.ModelClass.DTO;
using SazMart.DAL.ModelClass.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SazMart.Service.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBLLManager _userBLLManager;

        public UserController(IUserBLLManager userBLLManager)
        {
            _userBLLManager = userBLLManager;
        }

        [HttpPost("AddUser")]
        public async Task<ActionResult<AppUser>>AddUser(AppUser appUser)
        {
            if (await _userBLLManager.IsUserExist(appUser.Email)) return BadRequest("Email Already Exits");
            var user = await _userBLLManager.AddUserAsync(appUser);
            if (await _userBLLManager.SaveChangeAllAsync()) return NoContent();

            return BadRequest("Can't Registred Please try again!!!");

        }


        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAll()
        {
            return Ok(await _userBLLManager.GetAllUserAsync());
        }


        [HttpGet("{membername}")]
        public async Task<ActionResult<UserDTO>> GetMemberNameByAsync(string membername)
        {
            return Ok(await _userBLLManager.GetMemberNameByAsync(membername));
        }
    }
}
