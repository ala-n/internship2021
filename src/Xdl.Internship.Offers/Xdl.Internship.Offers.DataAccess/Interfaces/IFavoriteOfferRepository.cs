using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xdl.Internship.Core.DataAccess.MongoDB.Repositories;
using Xdl.Internship.Offers.Models;

namespace Xdl.Internship.Offers.DataAccess.Interfaces
{
    public interface IFavoriteOfferRepository : IMongoRepository<FavoriteOffer>
    {
        public Task<ICollection<FavoriteOffer>> FindAllFavoriteUserOffersAsync(string userId, CancellationToken cancellationToken = default);

        public Task<FavoriteOffer> FindOneFavoriteUserOfferAsync(string offerId, string userId, CancellationToken cancellationToken = default);

        public Task RemoveFavoriteUserOfferAsync(string offerId, string userId, CancellationToken cancellationToken = default);
    }
}
