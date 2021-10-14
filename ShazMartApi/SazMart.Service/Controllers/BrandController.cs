using BLLManager.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SazMart.DAL.ModelClass.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SazMart.Service.Controllers
{
    [Route("api/Brand")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandBLLManager _brandBLL;

        public BrandController(IBrandBLLManager brandBLL)
        {
            _brandBLL = brandBLL;
        }


        [HttpPost("AddBrand")]

        public async Task<ActionResult<Brand>>AddBrand(Brand brand)
        {
            if (await _brandBLL.IsExits(brand.BrandName)) return BadRequest("Brand Already Taken");
            var result = await _brandBLL.AddBrandAsync(brand);

            if (await _brandBLL.SaveAllAsync()) return NoContent();
            return BadRequest("Try Again");
        }


        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Brand>>> GetAll()
        {
            return Ok(await _brandBLL.GetAll());
        }
    }
}
