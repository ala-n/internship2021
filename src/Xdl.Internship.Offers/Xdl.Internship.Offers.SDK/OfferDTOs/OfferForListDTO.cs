using System;
using System.Collections.Generic;
using System.Text;

namespace Xdl.Internship.Offers.SDK.OfferDTOs
{
    public class OfferForListDTO
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public int NumberOfViews { get; set; }

        public int NumberOfUses { get; set; }

        public string Discount { get; set; }

        public int Rate { get; set; }

        public string UpdatedAt { get; set; }

        public string[] PhotoUrl { get; set; }
    }
}
