using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Products.Api.Data;
using Products.Domain.Entities;
namespace Products.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly DataContext _context;

        public ProductsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductsVentral>>> GetAllProduct()
        {
            var prod = await _context.products.ToListAsync();
            
            return Ok(prod);
        }


        [HttpGet("getForId")]

        public async Task<ActionResult<ProductsVentral>> GetUser(int id)
        {
            var users = await _context.products.FindAsync(id);
            if (users is null)

                return NotFound("Not found user");

            return Ok(users);
        }


        [HttpPost]
        public async Task<ActionResult<List<ProductsVentral>>> AddUser(ProductsVentral users)
        {
            _context.products.Add(users);
            await _context.SaveChangesAsync();

            return Ok(await _context.products.ToListAsync());
        }
        [HttpPut]

        public async Task<ActionResult<List<ProductsVentral>>> UpdateUser(ProductsVentral updateUser)
        {
            var dbuser = await _context.products.FindAsync(updateUser.Id);
            if (dbuser is null)

                return NotFound("Not found user");
            dbuser.Name = updateUser.Name;
            dbuser.Description = updateUser.Description;
            dbuser.UnitPrice= updateUser.UnitPrice;
            dbuser.Stock = updateUser.Stock;
            dbuser.Category = updateUser.Category;

            await _context.SaveChangesAsync();

            return Ok(await _context.products.ToListAsync());
        }

        [HttpDelete]

        public async Task<ActionResult<List<ProductsVentral>>> DeleteUser(int id)
        {
            var dbuser = await _context.products.FindAsync(id);
            if (dbuser is null)

                return NotFound("Not found user");
            _context.products.Remove(dbuser);
            await _context.SaveChangesAsync();

            return Ok(await _context.products.ToListAsync());
        }
    }
}
