using MongoDB.Bson;

namespace Xdl.Internship.Offers.SDK.OffersDTOs
{
    public class OfferMainDTO
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string VendorName { get; set; }

        public int NumberOfViews { get; set; }

        public int NumberOfUses { get; set; }

        public string Discount { get; set; }

        public int Rating { get; set; }
    }
}
