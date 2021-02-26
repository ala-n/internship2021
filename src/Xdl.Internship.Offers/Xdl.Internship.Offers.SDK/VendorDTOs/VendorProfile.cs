using AutoMapper;
using Xdl.Internship.Offers.DTOs.VendorDTOs;
using Xdl.Internship.Offers.Models;
using Xdl.Internship.Offers.SDK.VendorEntityDTOs;

namespace Xdl.Internship.Offers.SDK.VendorDTOs
{
    public class VendorProfile : Profile
    {
        public VendorProfile()
        {
            CreateMap<Vendor, VendorDTO>();

            CreateMap<VendorDTO, VendorWithEntitiesDTO>();
            CreateMap<VendorEntityDTO, VendorWithEntitiesDTO>()
                .ForMember(dest => dest.VendorEntities, opt => opt.MapFrom(src => src));
        }
    }
}
