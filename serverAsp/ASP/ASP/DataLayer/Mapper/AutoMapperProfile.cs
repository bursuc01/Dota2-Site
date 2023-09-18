using ASP.DataLayer.DataTransferObject;
using ASP.DataLayer.Models;
using AutoMapper;

namespace ASP.DataLayer.Mapper
{
        public class AutoMapperProfile : Profile
        {
            public AutoMapperProfile()
            {
                CreateMap<User, UserDTO>().ReverseMap();
                CreateMap<HeroToUsers, HeroToUserDTO>().ReverseMap();
                CreateMap<Hero, HeroDTO>().ReverseMap();
                CreateMap<Power, PowerDTO>().ReverseMap();
                CreateMap<Stats, StatsDTO>().ReverseMap();
                CreateMap<Roles, RolesDTO>().ReverseMap();
        }
        }
}
