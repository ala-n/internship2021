using System;

namespace Xdl.Internship.Offers.SDK.TagDTOs
{
    public class TagStatisticsDTO
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int UsesByUser { get; set; }

        public int UsesByVendor { get; set; }

        public bool IsDeleted { get; set; }
    }
}
