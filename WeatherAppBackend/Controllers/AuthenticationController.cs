using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeatherAppBackend.Models;
using WeatherAppBackend.Models.DTO;
using WeatherAppBackend.Service;
using WeatherAppBackend.Service.Auth;

namespace WeatherAppBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAuthService _authService;

        public AuthenticationController(IUserService userService, IAuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }

        [HttpPost("register")]
        public ActionResult<UserDTO> Register(RegistrationDTO registrationDTO)
        {
            var user = _userService.CreateUser(registrationDTO);
            return Ok(user);
        }

        [HttpPost("login")]
        public ActionResult<string> Login(LoginDTO loginDTO)
        {
            var DoesUserExist = _userService.DoesUserExistWithEmail(loginDTO.Email);
            if (!DoesUserExist)
            {
                return BadRequest(String.Format("User with provided email: {0} does not exist", loginDTO.Email));
            }
            if (!_authService.VerifyPassword(loginDTO.Password,loginDTO.Email))
            {
                return BadRequest("Wrong provided password");
            }
            return Ok(_authService.GenerateToken(loginDTO.Email));
        }
    }
}
