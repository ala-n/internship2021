using System;
using System.Collections.Generic;
using System.Text;
using Xdl.Internship.Core.Models.MongoDB;

namespace Xdl.Internship.Offers.DTOs.VendorDTOs
{
    public class GetVendor : ModelBase
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string WebSite { get; set; }
    }
}
