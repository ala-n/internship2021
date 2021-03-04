using System;

namespace Xdl.Internship.Offers.SDK.FeedbackDTOs
{
    public class FeedbackDTO
    {
        public string Id { get; set; }

        public string OfferId { get; set; }

        public string CreatedBy { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public string UpdatedBy { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }

        public string UserId { get; set; }

        public string VendorEntityId { get; set; }

        public int Rate { get; set; }
    }
}
