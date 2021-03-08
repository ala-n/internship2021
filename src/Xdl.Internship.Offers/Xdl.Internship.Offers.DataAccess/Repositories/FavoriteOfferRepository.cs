using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Xdl.Internship.Core.DataAccess.MongoDB.CollectionProviders;
using Xdl.Internship.Core.DataAccess.MongoDB.Repositories;
using Xdl.Internship.Offers.DataAccess.Interfaces;
using Xdl.Internship.Offers.Models;

namespace Xdl.Internship.Offers.DataAccess.Repositories
{
    public class FavoriteOfferRepository : MongoRepositoryBase<FavoriteOffer>, IFavoriteOfferRepository
    {
        public FavoriteOfferRepository(ICollectionProvider collectionProvider)
            : base(collectionProvider)
        {
        }

        public Task<ICollection<FavoriteOffer>> FindAllFavoriteUserOffersAsync(string offerId, string userId, CancellationToken cancellationToken = default)
        {
            Expression<Func<FavoriteOffer, bool>> filter = (v) => v.OfferId.ToString() == offerId && v.UserId.ToString() == userId;
            return FindAsync(filter, cancellationToken);
        }
    }
}
