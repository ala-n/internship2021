using System;
using AutoMapper;
using Xdl.Internship.Offers.Models;
using Xdl.Internship.Offers.SDK.VendorEntityDTOs;

namespace Xdl.Internship.Offers.SDK.VendorDTOs
{
    public class VendorProfile : Profile
    {
        public VendorProfile()
        {
            CreateMap<Vendor, VendorDTO>();

            CreateMap<Vendor, VendorWithEntitiesDTO>();
            CreateMap<VendorEntity, VendorWithEntitiesDTO>()
                .ForMember(dest => dest.VendorEntities, opt => opt.MapFrom(src => src));

            CreateMap<CreateVendorDTO, Vendor>()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTimeOffset.Now))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTimeOffset.Now));

            CreateMap<UpdateVendorDTO, Vendor>()
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTimeOffset.Now));
        }
    }
}
