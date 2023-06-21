using AutoMapper;
using BCrypt.Net;
using WeatherAppBackend.Models;
using WeatherAppBackend.Models.DTO;
using WeatherAppBackend.Repository;

namespace WeatherAppBackend.Service.Impl
{
    public class UserService : IUserService
    {
        private readonly IUserRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository<User> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public UserDTO CreateUser(RegistrationDTO dto)
        {
            if (GetUserByEmail(dto.Email) != null)
                throw new BadHttpRequestException(String.Format("Email: {0} is already taken", dto.Email));
            User user = _mapper.Map<User>(dto);
            //hash the value of the password from the dto
            //using the HCMASHA256 hashing algorithm
            user.Password = BCrypt.Net.BCrypt.EnhancedHashPassword(dto.Password,HashType.SHA256);
            var createdUser = _userRepository.Create(user);
            return _mapper.Map<UserDTO>(createdUser);
        }

        public bool DoesUserExistWithEmail(string email)
        {
            var user = _userRepository.GetUserByEmail(email);
            return user != null;
        }

        public UserDTO GetUserByEmail(string email)
        {
            var user = _userRepository.GetUserByEmail(email);
            return _mapper.Map<UserDTO>(user);
        }

        public UserDTO GetUserById(Guid id)
        {
            var user = _userRepository.GetById(id);
            return _mapper.Map<UserDTO>(user);
        }

        public List<UserDTO> GetUsers()
        {
            var users = _userRepository.GetAll();
            return _mapper.Map<List<UserDTO>>(users);
        }
    }
}
