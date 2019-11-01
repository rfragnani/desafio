using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using challenge.Data;
using challenge.Models;
using System.Linq;

namespace challenge.Controllers
{

    [ApiController]
    [Route("v1/products")]
    public class ProductController : ControllerBase
    {


        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Product>>> Get([FromServices] DataContext context)
        {
            var products = await context.Products.Include(p => p.Category).ToListAsync();
            return products;
        }

        [HttpGet]
        [Route("id:int")]
        public async Task<ActionResult<Product>> GetById([FromServices] DataContext context, int id)
        {
            var product = await context.Products.Include(p => p.Category)
                          .AsNoTracking()
                          .FirstOrDefaultAsync(p => p.id.Equals(id));

            return product;
        }

        [HttpGet]
        [Route("categories/id:int")]
        public async Task<ActionResult<List<Product>>> GetByCategory([FromServices] DataContext context, int id)
        {
            var product = await context.Products.Include(p => p.Category)
                          .AsNoTracking().Where(p => p.CategoryId.Equals(id)).ToListAsync();

            return product;
        }


        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Product>> Post(
            [FromServices] DataContext context,
            [FromBody] Product model)
        {
            if (ModelState.IsValid)
            {
                context.Products.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }


}