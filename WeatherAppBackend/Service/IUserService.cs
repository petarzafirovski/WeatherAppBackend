using WeatherAppBackend.Models.DTO;

namespace WeatherAppBackend.Service
{
    public interface IUserService
    {
        UserDTO CreateUser(RegistrationDTO dto);
        UserDTO GetUserByEmail(string email);
        UserDTO GetUserById(Guid id);
        List<UserDTO> GetUsers();
        bool DoesUserExistWithEmail(string email);
    }
}
