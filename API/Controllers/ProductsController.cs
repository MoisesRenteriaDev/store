using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class ProductsController(StoreContext context) : BaseApiController
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProductsAsync()
        {
            var products = await context.Products.ToListAsync();

            return Ok(products);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>> GetProductAsync(int id)
        {
            var product = await context.Products.FindAsync(id);

            if (product == null) return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> AddProduct(Product product)
        {
            context.Products.Add(product);

            await context.SaveChangesAsync();

            return Ok(product);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateProduct(int id, Product product)
        {
            if (product.Id != id || !ProductExists(id))
                return BadRequest("Cannot update this product!");

            context.Entry(product).State = EntityState.Modified;

            await context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var product = await context.Products.FindAsync(id);

            if (product == null) return NotFound();

            context.Products.Remove(product);

            await context.SaveChangesAsync();

            return NoContent();
        }


        private bool ProductExists(int id)
        {
            return context.Products.Any(p => p.Id == id);
        }
    }
}