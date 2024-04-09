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
        public async Task<ActionResult<UserDto>> GetUserById(Guid id)
        {
            var user = await _userService.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }
            else
            {
                return new UserDto(user.UserId, user.Name, user.Email);
            }
        }


        [HttpPost(Name = "CreateUser")]
        public ActionResult<User> CreateUser([FromBody] User user)
        {
            if (!ModelState.IsValid || user is null )
            {
                return BadRequest();
            }

            user.Password =  Hash.HashGeneration(user.Password);

            _userService.CreateUser(user);

            var userDTO = new UserDto(user.UserId, user.Name, user.Email);

            return CreatedAtAction("GetUserById", new { id = user.UserId }, userDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditUser(Guid id, User user)
        {
            if  (user == null)
            {
                throw new ArgumentNullException("O usuário não pode ser nulo");
            }
            if (id != user.UserId)
            {
                return BadRequest("O ID do usuário não corresponde ao ID na URL");
            }

            try
            {
                _userService.UpdateUser(user);
            }catch (Exception) 
            {
                var userExists = await _userService.GetUserById(id);

                if (userExists == null)
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
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var deleteUser = await _userService.GetUserById(id);

            if (deleteUser == null)
            {
                return NotFound();
            }
 
            _userService.DeleteUser(deleteUser);
            return NoContent();
        }
    }
}
