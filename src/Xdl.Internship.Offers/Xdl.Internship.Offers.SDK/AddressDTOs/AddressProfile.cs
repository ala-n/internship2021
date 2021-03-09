using AutoMapper;
using Xdl.Internship.Offers.Models;

namespace Xdl.Internship.Offers.SDK.AddressDTOs
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<Address, AddressDTO>()
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country))
                .ForMember(dest => dest.CityId, opt => opt.MapFrom(src => src.CityId))
                .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Street))
                .ForMember(dest => dest.House, opt => opt.MapFrom(src => src.House))
                .ForMember(dest => dest.Room, opt => opt.MapFrom(src => src.Room));
        }
    }
}
