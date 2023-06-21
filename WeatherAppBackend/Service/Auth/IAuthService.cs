using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using WeatherAppBackend.Models;

namespace WeatherAppBackend.Service.Auth
{
    public interface IAuthService
    {
        string GenerateToken(string userEmail);
        bool VerifyPassword(string dtoPassword, string dtoEmail);
    }
}
