using System.ComponentModel.DataAnnotations;

namespace WeatherAppBackend.Models.DTO
{
    public class RegistrationDTO
    {
        [Required(AllowEmptyStrings = false)]
        public string FirstName { get; set; } = string.Empty;

        [Required(AllowEmptyStrings = false)]
        public string LastName { get; set; } = string.Empty;

        [Required(AllowEmptyStrings = false)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required(AllowEmptyStrings = false)]
        public string Password { get; set; } = string.Empty;
    }
}
