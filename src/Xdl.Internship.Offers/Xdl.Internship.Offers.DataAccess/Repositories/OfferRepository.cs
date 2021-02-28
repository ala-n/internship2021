using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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

        public async Task<ICollection<Offer>> FindActiveAsync()
        {
            Expression<Func<Offer, bool>> filter = (v) => v.IsActive == true;
            return await FindAsync(filter);
        }

        public Task<Offer> FindOfferById(ObjectId offerId)
        {
            return FindByIdAsync(offerId);
        }

        public Task<ICollection<Offer>> FindOffersByCityId(ObjectId cityId)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Offer>> FindOffersByVendorId(ObjectId vendorId)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Offer>> FindOfferByVendorEntityId(ObjectId vendorEntityId)
        {
            throw new NotImplementedException();
        }
    }
}
