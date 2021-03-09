using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Bson;
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

        public Task<ICollection<FavoriteOffer>> FindAllFavoriteUserOffersAsync(string userId, CancellationToken cancellationToken = default)
        {
            Expression<Func<FavoriteOffer, bool>> filter = (v) => v.UserId == new ObjectId(userId);
            return FindAsync(filter, cancellationToken);
        }

        public Task<FavoriteOffer> FindOneFavoriteUserOfferAsync(string offerId, string userId, CancellationToken cancellationToken = default)
        {
            Expression<Func<FavoriteOffer, bool>> filter = (v) => v.UserId == new ObjectId(userId) && v.OfferId == new ObjectId(offerId);
            return FindOneAsync(filter, cancellationToken);
        }

        public Task RemoveFavoriteUserOfferAsync(string offerId, string userId, CancellationToken cancellationToken = default)
        {
            Expression<Func<FavoriteOffer, bool>> filter = (v) => v.UserId == new ObjectId(userId) && v.OfferId == new ObjectId(offerId);
            return DeleteOneAsync(filter, cancellationToken);
        }
    }
}
