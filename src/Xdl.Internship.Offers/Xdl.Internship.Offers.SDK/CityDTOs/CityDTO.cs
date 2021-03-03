using System;

namespace Xdl.Internship.Offers.SDK.CityDTOs
{
    public class CityDTO
    {
        public string Id { get; set; }

        public string CreatedBy { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public string UpdatedBy { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }

        public string Name { get; set; }
    }
}
