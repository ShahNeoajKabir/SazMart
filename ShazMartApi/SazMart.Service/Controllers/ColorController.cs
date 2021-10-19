using BLLManager.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SazMart.DAL.ModelClass.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SazMart.Service.Controllers
{
    [Route("api/Color")]
    [ApiController]
    public class ColorController : ControllerBase
    {
        private readonly IColorBLLManager _bLLManager;

        public ColorController(IColorBLLManager bLLManager)
        {
            _bLLManager = bLLManager;
        }

        [HttpPost("AddColor")]
        public async Task<ActionResult>AddColor(ColorDTO colorDTO)
        {
            await _bLLManager.AddColor(colorDTO);

            if (await _bLLManager.SaveAllAsync()) return NoContent();
            return BadRequest("Try Agin");

        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<ColorDTO>>> GetAll()
        {
            return Ok( await _bLLManager.GetAll());
        }
    }
}
