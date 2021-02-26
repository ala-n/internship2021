using MongoDB.Bson;

namespace Xdl.Internship.Offers.DTOs.VendorDTOs
{
    public class VendorMainDTO
    {
        public ObjectId Id { get; set; }

        public string Name { get; set; }

        public string Title { get; set; }

        public string Website { get; set; }

        public string Description { get; set; }
    }
}
