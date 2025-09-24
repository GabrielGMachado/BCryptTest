using BCryptTest.Models;
using BCryptTest.Repository;
using BCryptTest.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BCryptTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HashPassController : ControllerBase
    {
        public readonly IUserRepository _userRepository;

        public HashPassController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]

        public IActionResult Register(
            [FromBody] UserRequestJson request)
        {
            var newUser = new User
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Email = request.Email,
                Password = request.Password,
            };

            newUser.Password = BCrypt.Net.BCrypt.EnhancedHashPassword(request.Password, 13);

            _userRepository.Add(newUser);
            _userRepository.Update();

            return Created();
        }
    }
}
