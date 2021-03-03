using System;
using AutoMapper;
using Xdl.Internship.Offers.Models;

namespace Xdl.Internship.Offers.SDK.CityDTOs
{
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<City, CityDTO>();

            CreateMap<CreateCityDTO, City>()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTimeOffset.Now))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => true));
        }
    }
}
