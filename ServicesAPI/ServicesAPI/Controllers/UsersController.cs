using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicesAPI.Data;
using ServicesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IEnumerable<Users> Get()
        {
            return _context.Users.ToList();
        }
        [HttpGet("Id")]
        public Users Get([FromQuery] int Id)
        {
            return _context.Users.Where(user => user.Id == Id).FirstOrDefault();
        }
        [HttpPost]
        public Users AddUser([FromQuery] Users user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }
    }
}
