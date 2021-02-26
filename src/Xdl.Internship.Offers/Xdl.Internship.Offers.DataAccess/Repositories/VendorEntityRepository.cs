﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Bson;
using Xdl.Internship.Core.DataAccess.MongoDB.CollectionProviders;
using Xdl.Internship.Core.DataAccess.MongoDB.Repositories;
using Xdl.Internship.Offers.Models;

namespace Xdl.Internship.Offers.DataAccess.Repositories
{
    public interface IVendorEntityRepository
    {
        Task<ICollection<VendorEntity>> FindAllFilterByCityAsync(ObjectId cityId, bool onlyActive);

        Task<ICollection<VendorEntity>> FindActiveAsync();
    }

    public class VendorEntityRepository : MongoRepositoryBase<VendorEntity>, IVendorEntityRepository
    {
        public VendorEntityRepository(ICollectionProvider collectionProvider)
            : base(collectionProvider)
        {
        }

        public Task<ICollection<VendorEntity>> FindActiveAsync()
        {
            Expression<Func<VendorEntity, bool>> filter = (v) => v.IsActive == true;
            return FindAsync(filter);
        }

        public Task<ICollection<VendorEntity>> FindAllFilterByCityAsync(ObjectId cityId, bool onlyActive)
        {
            // Expression<Func<VendorEntity, bool>> filter = (v) => (cityId == null || v.Adress.CityId == cityId) && (!onlyActive || v.IsActive == true);
            return FindAsync(null);
        }
    }
}
