using BCryptTest.Context;
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
        public readonly UserContext _dbContext;

        public HashPassController(
            IUserRepository userRepository,
            UserContext dbContext)
        {
            _userRepository = userRepository;
            _dbContext = dbContext;
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
                Password = BCrypt.Net.BCrypt.EnhancedHashPassword(request.Password, 13)
            };

            _userRepository.Add(newUser);
            _userRepository.Update();

            return Created();
        }

        [HttpPost("Pass")]

        public IActionResult VerifyPassword(
            [FromBody] UserLoginRequestJson request)
        {
            var user = _dbContext.users.FirstOrDefault(u => u.Name == request.Name);
            if (user == null)
            {
                return Ok(false);
            }

            bool IsValid = BCrypt.Net.BCrypt.EnhancedVerify(request.Password, user.Password);

            return Ok(IsValid);
        }
    }
}
