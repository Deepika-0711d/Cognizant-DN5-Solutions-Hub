using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Models;
using ProductAPI.Services;

namespace ProductAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly ProductService productSvc;

        public ProductController()
        {
            productSvc = new ProductService();
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult<List<Product>> GetAllProducts()
        {
            var allProducts = productSvc.GetAllProducts();
            return Ok(allProducts);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<Product> GetProductDetail(int id)
        {
            var prod = productSvc.GetProductById(id);
            if (prod == null)
                return NotFound(new { error = "Product not found" });

            return Ok(prod);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult<Product> CreateProduct([FromBody] Product productData)
        {
            if (productData == null)
                return BadRequest(new { error = "Invalid product data" });

            var createdProd = productSvc.CreateProduct(productData);
            return CreatedAtAction(nameof(GetProductDetail), new { id = createdProd.productId }, createdProd);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult<Product> UpdateProduct(int id, [FromBody] Product productData)
        {
            if (productData == null)
                return BadRequest(new { error = "Invalid product data" });

            var updatedProd = productSvc.UpdateProduct(id, productData);
            if (updatedProd == null)
                return NotFound(new { error = "Product not found" });

            return Ok(updatedProd);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteProduct(int id)
        {
            var isDeleted = productSvc.DeleteProduct(id);
            if (!isDeleted)
                return NotFound(new { error = "Product not found" });

            return Ok(new { message = "Product deleted successfully" });
        }

        [HttpGet("category/{categoryName}")]
        [AllowAnonymous]
        public ActionResult<List<Product>> GetByCategory(string categoryName)
        {
            var categoryProducts = productSvc.SearchByCategory(categoryName);
            return Ok(categoryProducts);
        }

        [HttpGet("lowstock/{threshold}")]
        [Authorize(Roles = "Admin")]
        public ActionResult<List<Product>> GetLowStockItems(int threshold)
        {
            var lowStockItems = productSvc.GetLowStockProducts(threshold);
            return Ok(lowStockItems);
        }
    }
}
