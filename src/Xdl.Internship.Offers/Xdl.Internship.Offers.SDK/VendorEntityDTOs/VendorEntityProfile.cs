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
        }
    }
}
