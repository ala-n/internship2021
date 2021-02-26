using System;
using MongoDB.Bson;

namespace Xdl.Internship.Offers.SDK.VendorDTOs
{
    public class VendorDTO
    {
        public ObjectId Id { get; set; }

        public string CreatedBy { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public string UpdatedBy { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }

        public string Name { get; set; }

        public string Title { get; set; }

        public string Website { get; set; }

        public string Description { get; set; }

        public double Rate { get; set; }

        public bool IsActive { get; set; }
    }
}
