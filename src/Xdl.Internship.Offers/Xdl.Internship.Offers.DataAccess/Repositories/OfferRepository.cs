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
    public class OfferRepository : MongoRepositoryBase<Offer>, IOfferRepository
    {
        public OfferRepository(ICollectionProvider collectionProvider)
            : base(collectionProvider)
        {
        }

        public async Task<ICollection<Offer>> FindAsync(bool includeInactive, CancellationToken cancellationToken = default)
        {
            Expression<Func<Offer, bool>> filter = (v) => includeInactive || v.IsActive;
            return await FindAsync(filter);
        }

        public Task<ICollection<Offer>> FindByVendorIdAsync(ObjectId vendorId, CancellationToken cancellationToken = default)
        {
            Expression<Func<Offer, bool>> filter = (o) => o.Id == vendorId && o.IsActive;

            return FindAsync(filter);
        }

        public Task<ICollection<Offer>> FindByVendorEntityIdAsync(ObjectId vendorEntityId, bool includeInactive = false, CancellationToken cancellationToken = default)
        {
            Expression<Func<Offer, bool>> filter = (o) => o.VendorEntitiesId.Contains(vendorEntityId) && (includeInactive || o.IsActive);

            return FindAsync(filter);
        }
    }
}
