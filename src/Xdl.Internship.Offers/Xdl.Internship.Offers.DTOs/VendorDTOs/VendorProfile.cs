using AutoMapper;
using Xdl.Internship.Offers.DTOs.VendorEntityDTOs;
using Xdl.Internship.Offers.Models;

namespace Xdl.Internship.Offers.DTOs.VendorDTOs
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
