using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YMTDotNetTrainingBatch2.Database.AppDbContextModels;
using YMTDotNetTrainingBatch2.WebApi.Models;
using YMTDotNetTrainingBatch2.Domain.Features.ProductService;
namespace YMTDotNetTrainingBatch2.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        //GET : api/products
        [HttpGet]
        public IActionResult GetAllProducts()
        {   
            ProductService productService = new ProductService();
            List<TblProduct> products = productService.GetProducts();
            return Ok(products);
        }
        //GET : api/products/1

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            ProductService productService = new ProductService();
            var product = productService.FindProduct(id);
            if (product == null)
            {
                return NotFound("Product not found.");
            }
            return Ok(product);
        }

        //POST : api/products
        [HttpPost]
        public IActionResult CreateProduct([FromBody] TblProduct newProduct)
        {
            if(newProduct == null)
            {
                return BadRequest("Product data is invalid.");
            }
      
            ProductService productService = new ProductService();
            productService.CreateProduct(newProduct.ProductName, newProduct.Price);
            
            return CreatedAtAction(nameof(GetProductById), new { id = newProduct.ProductId }, newProduct);
        }

        //PUT : api/products/1
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] TblProduct updatedProduct)
        {
            if (updatedProduct == null || id != updatedProduct.ProductId)
            {
                return BadRequest("Product data is invalid or ID mismatch.");
            }
            ProductService productService = new ProductService();
            productService.UpdateProduct(id, updatedProduct.ProductName, updatedProduct.Price);
            return NoContent();
        }

        //DELETE : api/products/1
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            ProductService productService = new ProductService();
            productService.DeleteProduct(id);
            return NoContent();
        }


    }
    }
