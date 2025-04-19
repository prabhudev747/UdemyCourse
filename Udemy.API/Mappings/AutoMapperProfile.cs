using AutoMapper;
using Udemy.API.Models;

namespace Udemy.API.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Region, Region>().ReverseMap();
            //CreateMap<UserDTO, UserDomain>()
            //    .ForMember(x => x.Name,opt => opt.MapFrom(x => x.FullName))
            //    .ReverseMap();

        }
    }

    //public class UserDTO
    //{
    //    public string FullName { get; set; }
    //}
    //public class UserDomain
    //{
    //    public string Name { get; set; }
    //}
}
