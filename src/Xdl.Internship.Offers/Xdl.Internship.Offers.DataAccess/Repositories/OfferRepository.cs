﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
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

        // public async Task<ICollection<Offer>> GetOffersByCityId()
        // {
        // }
        public Task<ICollection<Offer>> GetOffersByVendorId()
        {
            throw new NotImplementedException();
        }
    }
}
