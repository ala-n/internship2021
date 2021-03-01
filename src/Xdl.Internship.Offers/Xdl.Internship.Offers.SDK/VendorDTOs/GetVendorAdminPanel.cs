using System;
using MongoDB.Bson;

namespace Xdl.Internship.Offers.SDK.VendorDTOs
{
    public class GetVendorAdminPanel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Website { get; set; }

        public bool IsActive { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }
    }
}
