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
    [Route("api/Categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesBLLManager _bLLManager;

        public CategoriesController(ICategoriesBLLManager bLLManager)
        {
            _bLLManager = bLLManager;
        }


        [HttpPost("AddCategories")]
        public async Task<ActionResult<Categories>>AddCategories(Categories categories)
        {
            if (await _bLLManager.IsExits(categories.Name)) return BadRequest("Categories Already Taken");
            var result = await _bLLManager.AddCategoriesAsync(categories);
            if (await _bLLManager.SaveAllAsync()) return NoContent();
            return BadRequest("Tray Again");
        }

        [HttpPost("AddSubCategories")]
        public async Task<ActionResult<SubCategories>> AddSubCategories(SubCategories categories)
        {
            var result = await _bLLManager.AddSubCategoriesByAsync(categories);
            if (await _bLLManager.SaveAllAsync()) return NoContent();
            return BadRequest("Tray Again");
        }


        [HttpGet ("GetAll")]

        public async Task<ActionResult<IEnumerable<CategoriesDTO>>> GetAll()
        {
            return Ok(await _bLLManager.GetCategories());
        }


        [HttpGet("{categoriesname}")]

        public async Task<ActionResult<CategoriesDTO>> GetCategoriesByName(string categoriesname)
        {
            return Ok(await _bLLManager.GetCategoriesByName(categoriesname));
        }

    }
}
