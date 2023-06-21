using System.ComponentModel.DataAnnotations;

namespace WeatherAppBackend.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string FirstName { get; set; } = string.Empty;

        [Required(AllowEmptyStrings = false)]
        public string LastName { get; set; } = string.Empty;

        [Required(AllowEmptyStrings = false)]
        public string Email { get; set; }  = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
