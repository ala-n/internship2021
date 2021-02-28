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
                .ForMember(x => x.Login, x => x.MapFrom(x => x.Login))
                .ForMember(x => x.FirstName, x => x.MapFrom(x => x.FirstName))
                .ForMember(x => x.LastName, x => x.MapFrom(x => x.LastName))
                .ForMember(x => x.City, x => x.MapFrom(x => x.City))
                .ForMember(x => x.IsActive, x => x.MapFrom(x => x.IsActive))
                .ForMember(x => x.PhotoUrl, x => x.MapFrom(x => x.PhotoUrl))
                .ReverseMap();
        }
    }
}
