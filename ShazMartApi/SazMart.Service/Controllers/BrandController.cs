using BLLManager.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SazMart.DAL.ModelClass.DTO;
using SazMart.DAL.ModelClass.ViewModel;
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
        private readonly IBrandBLLManager _bLLManager;

        public BrandController(IBrandBLLManager bLLManager)
        {
            _bLLManager = bLLManager;
        }

        [HttpPost]
        public async Task<ActionResult>UpsertBrand(BrandViewModel brand)
        {
            
            var res =await _bLLManager.Upsert(brand);
            return Ok(res);
        }


    }
}
