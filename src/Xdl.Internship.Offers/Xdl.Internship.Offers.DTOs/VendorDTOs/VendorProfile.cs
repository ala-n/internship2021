using AutoMapper;
using Xdl.Internship.Offers.Models;

namespace Xdl.Internship.Offers.DTOs.VendorDTOs
{
    public class VendorProfile : Profile
    {
        public VendorProfile()
        {
            CreateMap<Vendor, VendorDTO>();
        }
    }
}
