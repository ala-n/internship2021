using System;
using System.Collections.Generic;
using MongoDB.Bson;
using Xdl.Internship.Offers.SDK.VendorEntityDTOs;

namespace Xdl.Internship.Offers.SDK.OffersDTOs
{
    // getOfferById
    public class OfferMainDTO
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string[] PhotoUrl { get; set; }

        public string VendorName { get; set; }

        public int NumberOfViews { get; set; }

        public int NumberOfUses { get; set; }

        public string PromoCode { get; set; }

        public string Discount { get; set; }

        public string DateStart { get; set; }

        public string DateEnd { get; set; }

        public int Rating { get; set; }

        public ICollection<VendorEntityMainDTO> VendorEntities { get; set; }
    }
}
