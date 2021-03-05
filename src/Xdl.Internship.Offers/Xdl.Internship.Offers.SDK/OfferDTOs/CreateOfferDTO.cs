using System;

namespace Xdl.Internship.Offers.SDK.OfferDTOs
{
    public class CreateOfferDTO
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string[] PhotoUrl { get; set; }

        public string PromoCode { get; set; }

        public string Discount { get; set; }

        public DateTime DateStart { get; set; }

        public DateTime DateEnd { get; set; }

        public string[] VendorEntitiesId { get; set; }

        public string[] Tags { get; set; }

        public bool IsActive { get; set; }
    }
}
