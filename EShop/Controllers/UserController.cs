using EShop.Models.User;
using EShop.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserRequest request)
        {
            var user = await _userRepository.CreateUserAsync(request);
            if (user == null)
                return BadRequest("User allready exist");
            return Ok(user);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _userRepository.GetUserAsync(id);
            if (user == null)
                return NotFound("User not found");
            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await _userRepository.GetAllUsersAsync());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UserRequest request)
        {
            var user = await _userRepository.UpdateUserAsync(id, request);
            if (user == null)
                return NotFound("User not found");
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (await _userRepository.DeleteUserAsync(id))
                return Ok("Deleted user for id: " + id);
            return NotFound("User not found");
        }
    }
}
