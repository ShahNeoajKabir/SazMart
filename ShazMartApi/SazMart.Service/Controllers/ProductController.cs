using BLLManager.Interface;
using Microsoft.AspNetCore.Mvc;
using SazMart.DAL.ModelClass.DTO;
using SazMart.DAL.ModelClass.Entities;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SazMart.Service.Controllers
{
    [Route("api/Product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductBLLManager _productBLL;

        public ProductController(IProductBLLManager productBLL)
        {
            _productBLL = productBLL;
        }

        [HttpPost("AddProduct")]
        public async Task<ActionResult<Product>>AddProduct(Product product)
        {
            await _productBLL.AddProductAsync(product);
            if (await _productBLL.SaveAllAsync()) return NoContent();

            return BadRequest("Can't Added");
        }


        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAll()
        {
            return Ok(await _productBLL.GetAllProduct());
        }
    }
}
