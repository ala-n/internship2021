using Xdl.Internship.Core.DataAccess.MongoDB.CollectionProviders;
using Xdl.Internship.Core.DataAccess.MongoDB.Repositories;
using Xdl.Internship.Offers.Models;

namespace Xdl.Internship.Offers.DataAccess.Repositories
{
    public class FavoriteOfferRepository : MongoRepositoryBase<FavoriteOffer>
    {
        public FavoriteOfferRepository(ICollectionProvider collectionProvider)
            : base(collectionProvider)
        {
        }
    }
}
