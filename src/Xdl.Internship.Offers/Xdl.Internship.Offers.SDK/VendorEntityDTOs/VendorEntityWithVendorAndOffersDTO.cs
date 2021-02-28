using System;
using System.Collections.Generic;
using System.Text;
using Xdl.Internship.Offers.SDK.OfferDTOs;
using Xdl.Internship.Offers.SDK.VendorDTOs;

namespace Xdl.Internship.Offers.SDK.VendorEntityDTOs
{
    // getOfficeById
    public class VendorEntityWithVendorAndOffersDTO
    {
        public string Id { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string House { get; set; }

        public string Room { get; set; }

        public string Phone { get; set; }
    }
}
