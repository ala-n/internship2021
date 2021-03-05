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

            CreateMap<VendorEntity, VendorEntityForAdminDTO>()
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Adress.Country))
                .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Adress.Street))
                .ForMember(dest => dest.House, opt => opt.MapFrom(src => src.Adress.House))
                .ForMember(dest => dest.Room, opt => opt.MapFrom(src => src.Adress.Room));

            CreateMap<CreateVendorEntityDTO, VendorEntity>()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTimeOffset.Now));

            CreateMap<UpdateVendorEntityDTO, VendorEntity>()
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTimeOffset.Now));
        }
    }
}
