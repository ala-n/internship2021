using System;
using Xdl.Internship.Offers.SDK.AddressDTOs;

namespace Xdl.Internship.Offers.SDK.VendorEntityDTOs
{
    public class UpdateVendorEntityDTO
    {
        public string UpdatedBy { get; set; }

        public double[] Location { get; set; }

        public AddressDTO Address { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public bool IsActive { get; set; }

        public double Rate { get; set; }
    }
}
