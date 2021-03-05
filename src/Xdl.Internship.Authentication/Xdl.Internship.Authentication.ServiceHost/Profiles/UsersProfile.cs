using AutoMapper;
using Xdl.Internship.Authentication.DTOs;

namespace Xdl.Internship.Authentication.ServiceHost.Profiles
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<Models.User, User>()
                .ForMember(x => x.Id, x => x.MapFrom(x => x.Id.ToString()))
                .ForMember(x => x.FirstName, x => x.MapFrom(x => x.FirstName))
                .ForMember(x => x.LastName, x => x.MapFrom(x => x.LastName))
                .ForMember(x => x.CityId, x => x.MapFrom(x => x.City))
                .ForMember(x => x.IsActive, x => x.MapFrom(x => x.IsActive))
                .ForMember(x => x.PhotoUrl, x => x.MapFrom(x => x.PhotoUrl))
                .ForMember(x => x.Role, x => x.MapFrom(x => x.Role.ToString()))
                .ForMember(x => x.Phone, x => x.MapFrom(x => x.Phone))
                .ReverseMap();
        }
    }
}
