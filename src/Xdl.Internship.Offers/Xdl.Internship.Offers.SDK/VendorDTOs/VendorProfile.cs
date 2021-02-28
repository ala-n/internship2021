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
            Console.WriteLine(11);
            CreateMap<Vendor, VendorDTO>();

            CreateMap<VendorDTO, VendorWithEntitiesDTO>();
            CreateMap<VendorEntityDTO, VendorWithEntitiesDTO>()
                .ForMember(dest => dest.VendorEntities, opt => opt.MapFrom(src => src));
        }
    }
}
