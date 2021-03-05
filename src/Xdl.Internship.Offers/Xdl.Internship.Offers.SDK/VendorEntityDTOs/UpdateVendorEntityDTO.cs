using System;
using Xdl.Internship.Offers.SDK.AddressDTOs;

namespace Xdl.Internship.Offers.SDK.VendorEntityDTOs
{
    public class UpdateVendorEntityDTO
    {
        public string Phone { get; set; }

        public string Email { get; set; }

        public bool IsActive { get; set; }

        public double[] Location { get; set; }

        // public AddressDTO Address { get; set; }
        public string Country { get; set; }

        public string CityId { get; set; }

        public string Street { get; set; }

        public string House { get; set; }

        public string Room { get; set; }
    }
}
