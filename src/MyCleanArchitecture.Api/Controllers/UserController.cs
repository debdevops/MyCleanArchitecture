using Microsoft.AspNetCore.Mvc;
using MyCleanArchitecture.Application.Services;

namespace MyCleanArchitecture.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
        {
            await _userService.AddUserAsync(request.Name, request.Email);
            return CreatedAtAction(nameof(GetUserById), new { id = Guid.NewGuid() }, null);
        }
    }

    public record CreateUserRequest(string Name, string Email);
}
