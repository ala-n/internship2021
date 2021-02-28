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
        }
    }
}
