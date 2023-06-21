using System.ComponentModel.DataAnnotations;

namespace WeatherAppBackend.Models.DTO
{
    public class LoginDTO
    {
        [Required(AllowEmptyStrings = false)]
        public string Email { get; set; } = string.Empty;

        [Required(AllowEmptyStrings = false)]
        public string Password { get; set; } = string.Empty;
    }
}
