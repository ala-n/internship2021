using System;
using System.Collections.Generic;
using Xdl.Internship.Offers.SDK.VendorEntityDTOs;

namespace Xdl.Internship.Offers.SDK.VendorDTOs
{
    public class VendorWithEntitiesDTO
    {
        public string Id { get; set; }

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

        public ICollection<VendorEntityDTO> VendorEntities { get; set; }
    }
}
