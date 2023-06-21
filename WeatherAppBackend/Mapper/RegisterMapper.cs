using AutoMapper;
using WeatherAppBackend.Models;
using WeatherAppBackend.Models.DTO;

namespace WeatherAppBackend.Mapper
{
    public class RegisterMapper : Profile
    {
        public RegisterMapper()
        {
            CreateMap<User, UserDTO>()
                .ForMember(destProp => destProp.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(destProp => destProp.LastName, opt => opt.MapFrom(dst => dst.LastName))
                .ForMember(destProp => destProp.Email, opt => opt.MapFrom(dst => dst.Email));
        }
    }
}
