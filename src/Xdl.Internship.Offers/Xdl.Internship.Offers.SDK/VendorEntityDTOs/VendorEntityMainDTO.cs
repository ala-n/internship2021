using Xdl.Internship.Offers.SDK.AddressDTOs;

namespace Xdl.Internship.Offers.SDK.VendorEntityDTOs
{
    public class VendorEntityMainDTO
    {
        public string Id { get; set; }

        public AddressDTO Address { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public double[] Location { get; set; }
    }
}
