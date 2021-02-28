using AutoMapper;
using Xdl.Internship.Offers.Models;

namespace Xdl.Internship.Offers.SDK.AddressDTOs
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<Adress, AddressDTO>();
        }
    }
}
