using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Custumers.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Custumers.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Custumers.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustumersController : ControllerBase
    {
        private readonly DataContext _context;

        public CustumersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<UsersVentral>>> GetAllCustumers()
        {
            var users = await _context.clientes.ToListAsync();
            return Ok(users);
            
        }


        [HttpGet("getForId")]

        public async Task<ActionResult<UsersVentral>> GetUser(int id)
        {
            var users = await _context.clientes.FindAsync(id);
            if (users is null)

                return NotFound("Not found user");

            return Ok(users);
        }


        [HttpPost]
        public async Task<ActionResult<List<UsersVentral>>> AddUser(UsersVentral users)
        {
            _context.clientes.Add(users);
            await _context.SaveChangesAsync();

            return Ok(await _context.clientes.ToListAsync());
        }
        [HttpPut]

        public async Task<ActionResult<List<UsersVentral>>> UpdateUser(UsersVentral updateUser)
        {
            var dbuser = await _context.clientes.FindAsync(updateUser.Id);
            if (dbuser is null)

                return NotFound("Not found user");
            dbuser.Name = updateUser.Name;
            dbuser.LastName = updateUser.LastName;
            dbuser.Email = updateUser.Email;
            dbuser.Direction = updateUser.Direction;
            dbuser.NumberPhone = updateUser.NumberPhone;
            dbuser.DateRegister = updateUser.DateRegister;
            dbuser.LastDateRegister = updateUser.LastDateRegister;

            await _context.SaveChangesAsync();

            return Ok(await _context.clientes.ToListAsync());
        }

        [HttpDelete]

        public async Task<ActionResult<List<UsersVentral>>> DeleteUser(int id)
        {
            var dbuser = await _context.clientes.FindAsync(id);
            if (dbuser is null)

                return NotFound("Not found user");
            _context.clientes.Remove(dbuser);
            await _context.SaveChangesAsync();

            return Ok(await _context.clientes.ToListAsync());
        }

    }
}
