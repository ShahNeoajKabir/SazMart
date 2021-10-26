using BLLManager.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SazMart.DAL.ModelClass.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SazMart.Service.Controllers
{
    [Route("api/Category")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryBLLManager _bLLManager;

        public CategoriesController(ICategoryBLLManager bLLManager)
        {
            _bLLManager = bLLManager;
        }

        [HttpPost]
        public async Task<ActionResult>Upsert(CategoryViewModel viewModel)
        {
            return Ok(await _bLLManager.Upsert(viewModel));
        }

        [HttpGet]
        public List<CategoryViewModel> GetAll()
        {
            return _bLLManager.GetAll();
        }

        [HttpGet("Active")]
        public async Task<ActionResult<IEnumerable<CategoryViewModel>>> GetAllActive()
        {
            return Ok(await _bLLManager.GetAllActiveCategory());
        }

        [HttpPost("Delete")]
        public async Task<ActionResult> Delete(Guid Id)
        {
            return Ok(await _bLLManager.DeleteCategory(Id));
        }
    }
}
