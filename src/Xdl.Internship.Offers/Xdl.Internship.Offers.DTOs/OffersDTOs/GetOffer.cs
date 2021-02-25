using System;
using System.Collections.Generic;
using System.Text;
using Xdl.Internship.Core.Models.MongoDB;

namespace Xdl.Internship.Offers.DTOs.OffersDTOs
{
    public class GetOffer : ModelBase
    {
        public string Title { get; set; }

        public string VendorName { get; set; }
    }
}
