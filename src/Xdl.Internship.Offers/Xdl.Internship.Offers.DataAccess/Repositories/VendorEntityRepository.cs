using System;
using System.Collections.Generic;
using System.Linq;
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
        // READ
        Task<VendorEntity> FindByIdAsync(ObjectId id);

        Task<VendorEntity> FindOneByLocationAsync(double[] location);

        Task<ICollection<VendorEntity>> FindActiveAsync();

        Task<ICollection<VendorEntity>> FindByCityAsync(ObjectId cityId, bool onlyActive);

        Task<ICollection<VendorEntity>> FindByVendorId(ObjectId vendorId);

        // CREATE
        Task InsertOneAsync(VendorEntity vendorEntity);
    }

    public class VendorEntityRepository : MongoRepositoryBase<VendorEntity>, IVendorEntityRepository
    {
        public VendorEntityRepository(ICollectionProvider collectionProvider)
            : base(collectionProvider)
        {
        }

        // READ
        public Task<VendorEntity> FindByIdAsync(ObjectId id)
        {
            return base.FindByIdAsync(id);
        }

        public Task<VendorEntity> FindOneByLocationAsync(double[] location)
        {
            // Expression<Func<VendorEntity, bool>> filter = (v) => v.Location.SequenceEqual(location);
            Expression<Func<VendorEntity, bool>> filter = (v) => v.Location[0] == location[0] && v.Location[1] == location[1];
            return FindOneAsync(filter);
        }

        public Task<ICollection<VendorEntity>> FindActiveAsync()
        {
            Expression<Func<VendorEntity, bool>> filter = (v) => v.IsActive == true;
            return FindAsync(filter);
        }

        public Task<ICollection<VendorEntity>> FindByCityAsync(ObjectId cityId, bool onlyActive)
        {
            Expression<Func<VendorEntity, bool>> filter = (v) => v.Adress.CityId == cityId && (!onlyActive || v.IsActive);
            return FindAsync(filter);
        }

        public Task<ICollection<VendorEntity>> FindByVendorId(ObjectId vendorId)
        {
            Expression<Func<VendorEntity, bool>> filter = (v) => v.VendorId == vendorId;
            return FindAsync(filter);
        }

        // CREATE
        public Task InsertOneAsync(VendorEntity vendorEntity)
        {
            return base.InsertOneAsync(vendorEntity);
        }
    }
}
