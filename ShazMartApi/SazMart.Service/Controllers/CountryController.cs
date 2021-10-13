using BLLManager.Interface;
using Microsoft.AspNetCore.Mvc;
using SazMart.DAL.ModelClass.DTO;
using SazMart.DAL.ModelClass.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SazMart.Service.Controllers
{
    [Route("api/Country")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryBLLManager _countryBLL;

        public CountryController(ICountryBLLManager countryBLL)
        {
            _countryBLL = countryBLL;
        }

        [HttpPost("AddCountry")]

        public async Task<ActionResult<Country>> AddCountry(Country country)
        {
            if (await _countryBLL.IsExists(country.CountryName)) return BadRequest("Country Name Already Taken");
            var result = await _countryBLL.AddCountryAsync(country);

            if (await _countryBLL.SaveAllAsync()) return NoContent();

            return BadRequest("Can't Added . Please Try Again");
        }


        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<CountryDTO>>> GetAll()
        {
            return Ok(await _countryBLL.GetAllCountryAsync());
        }
    }
}
