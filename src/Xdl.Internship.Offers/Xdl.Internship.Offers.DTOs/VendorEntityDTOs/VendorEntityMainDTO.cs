using MongoDB.Bson;

namespace Xdl.Internship.Offers.DTOs.VendorEntityDTOs
{
    public class VendorEntityMainDTO
    {
        public ObjectId Id { get; set; }

        public string Street { get; set; }

        public string House { get; set; }

        public string Room { get; set; }

        public string Phone { get; set; }
    }
}
