using System;
using AutoMapper;
using Xdl.Internship.Offers.Models;

namespace Xdl.Internship.Offers.SDK.VendorEntityDTOs
{
    public class VendorEntityProfile : Profile
    {
        public VendorEntityProfile()
        {
            CreateMap<VendorEntity, VendorEntityDTO>();

            CreateMap<CreateVendorEntityDTO, VendorEntity>()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTimeOffset.Now));

            CreateMap<UpdateVendorEntityDTO, VendorEntity>()
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTimeOffset.Now));

            CreateMap<VendorEntityMainDTO, VendorEntity>()
                .ForPath(dest => dest.Adress.CityId, opt => opt.MapFrom(src => src.City))
                .ForPath(dest => dest.Adress.Street, opt => opt.MapFrom(src => src.Street))
                .ForPath(dest => dest.Adress.House, opt => opt.MapFrom(src => src.House))
                .ForPath(dest => dest.Adress.Room, opt => opt.MapFrom(src => src.Room))
                .ReverseMap();
        }
    }
}
