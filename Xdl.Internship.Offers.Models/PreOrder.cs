using MongoDB.Bson;
using Xdl.Internship.Core.Models.MongoDB;

namespace Xdl.Internship.Offers.Models
{
    public class PreOrder : CreationAwareModel
    {
        public ObjectId OfferId { get; set; }

        public ObjectId UserId { get; set; }

        public ObjectId VendorEntityId { get; set; }

        public string Description { get; set; }
    }
}
