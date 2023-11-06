using AutoMapper;
using BussinessObjects.Dtos.User;
using BussinessObjects.Models;

namespace BussinessObjects.Configurations
{
    public class MapperConfig : Profile
    {        
        public MapperConfig()
        {
            CreateMap<User, UserLoginResponse>().ReverseMap();
        }
    }
}
