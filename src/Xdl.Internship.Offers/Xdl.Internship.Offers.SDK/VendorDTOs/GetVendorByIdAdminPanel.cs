using MongoDB.Bson;

namespace Xdl.Internship.Offers.SDK.VendorDTOs
{
    public class GetVendorByIdAdminPanel
    {
        public ObjectId Id { get; set; }

        public string Name { get; set; }

        public string Title { get; set; }

        public string Website { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }
    }
}
