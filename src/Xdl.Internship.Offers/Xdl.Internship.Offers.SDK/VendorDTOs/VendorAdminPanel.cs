using System;
using System.Collections.Generic;
using System.Text;

namespace Xdl.Internship.Offers.SDK.VendorDTOs
{
    public class VendorAdminPanel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Website { get; set; }

        public bool IsActive { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }
    }
}
