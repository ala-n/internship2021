using System;
using System.Collections.Generic;
using System.Text;

namespace Xdl.Internship.Offers.SDK.VendorDTOs
{
    public class CreateVendorDTO
    {
        public string Name { get; set; }

        public string Title { get; set; }

        public string Website { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }
    }
}
