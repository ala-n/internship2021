using AutoMapper;
using Xdl.Internship.Authentication.DTOs;
using Xdl.Internship.Authentication.Models;

namespace Xdl.Internship.Authentication.ServiceHost.Profiles
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<User, UserRead>();
        }
    }
}
