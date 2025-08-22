using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YMTDotNetTrainingBatch2.BL;
using YMTDotNetTrainingBatch2.DB.AppDbContextModels;

namespace YMTDotNetTrainingBatch2.DI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;
        private readonly IConfiguration _configuration;


        public ProductsController(ProductService productService , IConfiguration configuration)
        {
            _productService = productService;
            _configuration = configuration;
        }

        [HttpGet("List/{pageNo}/{pageSize}")]
        public async Task<IActionResult> GetProductsAsync(int pageNo, int pageSize)
        {
            var products = await _productService.GetProductsAsync(pageNo, pageSize);
            return Ok(products);
            
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductAsync([FromBody] TblProduct newProduct)
        {
            if (newProduct == null)
            {
                return BadRequest("Product data is invalid.");
            }
            int result = await _productService.CreateProductAsync(newProduct);
            return Ok(result);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateProductAsync(int id, [FromBody] TblProduct updatedProduct)
        {
            int result = await _productService.UpdateProductAsync(id, updatedProduct);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductAsync(int id)
        {
            int result = await _productService.DeleteProductAsync(id);
            return Ok(result);
        }



        [HttpGet("GetConnectionString")]
        public IActionResult GetConnectionString()
        {
            return Ok(_configuration.GetConnectionString("DbConnection"));
        }
         
    }
}
