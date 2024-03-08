using MedicalScan.Services;
using Microsoft.AspNetCore.Mvc;

namespace MedicalScan.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet("getProduct/{id}")]
        public IActionResult GetProduct(int id)
        {
            Product product = productService.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpGet("getAllProducts")]
        public IActionResult GetAllProducts()
        {
            List<Product> products = productService.GetAllProducts();
            return Ok(products);
        }

        [HttpPut("updateProduct")]
        public IActionResult UpdateProduct([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest("A termék nem lehet üres.");
            }

            Product existingProduct = productService.GetProduct(product.Id);
            if (existingProduct == null)
            {
                return NotFound("A frissítendő termék nem található.");
            }
            productService.UpdateProduct(product);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            };

            return NoContent();
        }

        [HttpPost("addProduct")]
        public IActionResult AddProduct([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest("A termék nem lehet üres.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            productService.AddProduct(product);

            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        [HttpDelete("deleteProduct/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var existingProduct = productService.GetProduct(id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            productService.DeleteProduct(id);
            return NoContent();
        }
    }
}