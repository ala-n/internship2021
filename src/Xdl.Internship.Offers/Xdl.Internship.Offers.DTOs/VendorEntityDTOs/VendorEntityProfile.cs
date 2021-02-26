using AutoMapper;
using Xdl.Internship.Offers.Models;

namespace Xdl.Internship.Offers.DTOs.VendorEntityDTOs
{
    public class VendorEntityProfile : Profile
    {
        public VendorEntityProfile()
        {
            CreateMap<VendorEntity, VendorEntityDTO>();
        }
    }
}
