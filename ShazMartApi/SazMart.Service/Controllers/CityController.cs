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
    [Route("api/City")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityBLLManager _bLLManager;

        public CityController(ICityBLLManager bLLManager)
        {
            _bLLManager = bLLManager;
        }


        [HttpPost("AddCity")]
        public async Task<ActionResult<City>> AddCity(City city)
        {
            if (await _bLLManager.IsExists(city.CityName)) return BadRequest("City Name Already Taken");

            var result = await _bLLManager.AddCityAsync(city);
            if (await _bLLManager.SaveAllAsync()) return NoContent();
            return BadRequest("Can't Added !! Please Try Again");

        }


        [HttpGet("GetAll")]

        public async Task<ActionResult<IEnumerable<CityDTO>>> GetAll()
        {
            return Ok(await _bLLManager.GetAll());
        }
    }
}
