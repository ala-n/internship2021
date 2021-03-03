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
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTimeOffset.Now));

            CreateMap<Vendor, VendorAdminPanel>()
                .ForMember(x => x.Id, x => x.MapFrom(x => x.Id.ToString()))
                .ForMember(x => x.Name, x => x.MapFrom(x => x.Name))
                .ForMember(x => x.Website, x => x.MapFrom(x => x.Website))
                .ForMember(x => x.IsActive, x => x.MapFrom(x => x.IsActive))
                .ForMember(x => x.UpdatedAt, x => x.MapFrom(x => x.UpdatedAt));

            CreateMap<Vendor, VendorByIdAdminPanel>();
        }
    }
}
