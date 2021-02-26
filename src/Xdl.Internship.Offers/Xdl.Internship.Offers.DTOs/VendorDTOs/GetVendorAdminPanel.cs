using System;
using MongoDB.Bson;

namespace Xdl.Internship.Offers.DTOs.VendorDTOs
{
    public class GetVendorAdminPanel
    {
        public ObjectId Id { get; set; }

        public string Name { get; set; }

        public string Website { get; set; }

        public bool IsActive { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }
    }
}
