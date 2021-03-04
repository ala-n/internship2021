using System;
using Xdl.Internship.Offers.SDK.AddressDTOs;

namespace Xdl.Internship.Offers.SDK.VendorEntityDTOs
{
    public class UpdateVendorEntityDTO
    {
        public double[] Location { get; set; }

        public AddressDTO Address { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }
    }
}
