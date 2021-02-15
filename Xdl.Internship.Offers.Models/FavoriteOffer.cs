using MongoDB.Bson;
using Xdl.Internship.Core.Models.MongoDB;

namespace Xdl.Internship.Offers.Models
{
    public class FavoriteOffer : CreationAwareModel
    {
        public ObjectId OfferId { get; set; }

        public ObjectId UserId { get; set; }
    }
}