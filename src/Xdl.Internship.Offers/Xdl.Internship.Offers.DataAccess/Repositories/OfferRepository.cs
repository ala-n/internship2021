﻿using System;
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
            Expression<Func<VendorEntity, bool>> filter1 = (v) => v.Adress.CityId == cityId;
            Expression<Func<Offer, bool>> filter = (o) => o.Adress.CityId == cityId && o.IsActive;

            return FindAsync(filter);
        }

        public Task<ICollection<Offer>> FindOffersByVendorId(ObjectId vendorId)
        {
            Expression<Func<Offer, bool>> filter = (o) => o == vendorId && o.IsActive;

            return FindAsync(filter);
        }

        public Task<ICollection<Offer>> FindOfferByVendorEntityId(ObjectId vendorEntityId)
        {
            Expression<Func<Offer, bool>> filter = (o) => o.VendorEntitiesId.Contains(vendorEntityId) && o.IsActive;

            return FindAsync(filter);
        }
    }
}
