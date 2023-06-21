using BCrypt.Net;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WeatherAppBackend.Models;
using WeatherAppBackend.Repository;

namespace WeatherAppBackend.Service.Auth.Impl
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository<User> _userRepository;

        public AuthService(IConfiguration configuration, IUserRepository<User> userRepository)
        {
            _configuration = configuration;
            _userRepository = userRepository;
        }


        public string GenerateToken(string userEmail)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            var signInCredentials = new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                expires: DateTime.Now.AddDays(1),
                claims: Claims(userEmail),
                signingCredentials: signInCredentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private List<Claim> Claims(string email)
        {
            var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email,email),
                };
            return authClaims;
        }

        public bool VerifyPassword(string dtoPassword, string dtoEmail)
        {
            var user = _userRepository.GetUserByEmail(dtoEmail);
            if (user == null)
                return false;
            return BCrypt.Net.BCrypt.EnhancedVerify(dtoPassword, user.Password, HashType.SHA256);
        }
    }
}
