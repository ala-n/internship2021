using System;
using MongoDB.Bson;

namespace Xdl.Internship.Offers.SDK.TagDTOs
{
    public class TagDTO
    {
        public string Id { get; set; }

        public string CreatedBy { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public string UpdatedBy { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }

        public string Name { get; set; }

        public int UsesByUser { get; set; }

        public int UsesByVendor { get; set; }

        public bool IsDeleted { get; set; }
    }
}
