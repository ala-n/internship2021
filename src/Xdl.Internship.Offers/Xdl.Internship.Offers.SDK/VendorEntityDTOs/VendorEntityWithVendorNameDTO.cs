using System;
using Xdl.Internship.Offers.SDK.AddressDTOs;

namespace Xdl.Internship.Offers.SDK.VendorEntityDTOs
{
    public class VendorEntityWithVendorNameDTO
    {
        public string Id { get; set; }

        public string CreatedBy { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public string UpdatedBy { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }

        public double[] Location { get; set; }

        public AddressDTO Address { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string VendorId { get; set; }

        public string VendorName { get; set; }

        public bool IsActive { get; set; }

        public double Rate { get; set; }
    }
}
