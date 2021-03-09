using System;
using AutoMapper;
using Xdl.Internship.Offers.Models;
using Xdl.Internship.Offers.SDK.Identity;
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

            // Create
            CreateMap<CreateVendorDTO, Vendor>()
                .ForMember(dest => dest.Rate, opt => opt.MapFrom(src => 0))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTimeOffset.Now))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTimeOffset.Now));

            CreateMap<CreateIdentity, Vendor>()
               .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.GetValue()))
               .ForMember(dest => dest.UpdatedBy, opt => opt.MapFrom(src => src.GetValue()));

            // Update
            CreateMap<UpdateVendorDTO, Vendor>()
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTimeOffset.Now));

            CreateMap<UpdateIdentity, Vendor>()
              .ForMember(dest => dest.UpdatedBy, opt => opt.MapFrom(src => src.GetValue()));
        }
    }
}
