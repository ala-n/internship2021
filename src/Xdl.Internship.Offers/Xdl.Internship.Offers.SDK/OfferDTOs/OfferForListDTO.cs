using System;
using System.Collections.Generic;
using System.Text;

namespace Xdl.Internship.Offers.SDK.OfferDTOs
{
    // getOffers
    public class OfferForListDTO
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string VendorName { get; set; }

        public string NumberOfViews { get; set; }

        public string NumberOfUses { get; set; }

        public string Discount { get; set; }

        public string Rating { get; set; }

        public string UpdatedAt { get; set; }

        public string PhotoUrl { get; set; }
    }
}
