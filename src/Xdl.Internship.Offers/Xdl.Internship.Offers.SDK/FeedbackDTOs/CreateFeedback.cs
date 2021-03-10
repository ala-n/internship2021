using System;
using System.Collections.Generic;
using System.Text;

namespace Xdl.Internship.Offers.SDK.FeedbackDTOs
{
    public class CreateFeedback
    {
        public string OfferId { get; set; }

        public string VendorId { get; set; }

        public int Rate { get; set; }
    }
}
