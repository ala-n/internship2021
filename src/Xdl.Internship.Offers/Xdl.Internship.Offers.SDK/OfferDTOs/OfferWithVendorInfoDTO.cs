using System;
using System.Collections.Generic;
using System.Text;
using Xdl.Internship.Offers.SDK.VendorDTOs;
using Xdl.Internship.Offers.SDK.VendorEntityDTOs;

namespace Xdl.Internship.Offers.SDK.OfferDTOs
{
    public class OfferWithVendorInfoDTO
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public int NumberOfViews { get; set; }

        public int NumberOfUses { get; set; }

        public string Discount { get; set; }

        public double Rate { get; set; }

        public string UpdatedAt { get; set; }

        public string[] PhotoUrl { get; set; }

        public string VendorId { get; set; }

        public string VendorName { get; set; }

        public ICollection<string> Tags { get; set; }

        public ICollection<VendorEntityMainDTO> VendorEntities { get; set; }
    }
}
