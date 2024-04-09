using Business.Interfaces;
using Data.Context;
using Data.DTO;
using Data.helpers;
using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Data.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController(ILogger<UserController> logger, IUserService userService, AppDbContext appDbContext) : ControllerBase
    {
        private readonly ILogger<UserController> _logger = logger;
        private readonly IUserService _userService = userService;
        private readonly AppDbContext _appDbContext = appDbContext;


        [Authorize]
        [HttpGet(Name = "findUsers")]
        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            var users = await _userService.GetUsers();
           
            return users.Select(user => new UserDto(user.UserId, user.Name, user.Email));
            
        }

        [Authorize]
        [HttpGet("{id}", Name = "FindUserById")]
        public  User? GetUserById(Guid id)
        {
            //var user = await _appDbContext.Users.FirstOrDefaultAsync(u => u.UserId == id);
            var user =  _userService.GetUserById(id);
            return user;
            //return user.Select(user => new UserDto(user.UserId, user.Name, user.Email));
        }


        [HttpPost(Name = "CreateUser")]
        public async Task<ActionResult<UserDto>> CreateUser([FromBody] User user)
        {
            if (!ModelState.IsValid || user is null )
            {
                return BadRequest();
            }

            user.Password =  Hash.HashGeneration(user.Password);

            _appDbContext.Users.Add(user);
            await _appDbContext.SaveChangesAsync();

            var userDTO = new UserDto(user.UserId, user.Name, user.Email);

            return CreatedAtAction("GetUserById", new { id = user.UserId }, userDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditUser(Guid id, User user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }

            _appDbContext.Entry(user).State = EntityState.Modified;
            try
            {
                await _appDbContext.SaveChangesAsync();
            }catch (DbUpdateConcurrencyException) 
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var deleteUser = await _appDbContext.Users.FindAsync(id);

            if (deleteUser == null)
            {
                return NotFound();
            }
            _appDbContext.Users.Remove(deleteUser);
            await _appDbContext.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(Guid id)
        {
            return _appDbContext.Users.Any(e => e.UserId == id);
        }
    }
}
