using System;
using System.Collections.Generic;
using System.Text;
using Xdl.Internship.Offers.SDK.VendorEntityDTOs;

namespace Xdl.Internship.Offers.SDK.OfferDTOs
{
    public class OfferWithAllInfoDTO
    {
        public string Id { get; set; }

        public string CreatedBy { get; set; }

        public string CreatedAt { get; set; }

        public string UpdatedBy { get; set; }

        public string UpdatedAt { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string[] PhotoUrl { get; set; }

        public string PromoCode { get; set; }

        public string Discount { get; set; }

        public string DateStart { get; set; }

        public string DateEnd { get; set; }

        public ICollection<VendorEntityMainDTO> VendorEntities { get; set; }

        public ICollection<string> Tags { get; set; }

        public int NumberOfUses { get; set; }

        public int NumberOfViews { get; set; }

        public double Rate { get; set; }

        public bool IsActive { get; set; }

        public string VendorId { get; set; }

        public string VendorName { get; set; }
    }
}
