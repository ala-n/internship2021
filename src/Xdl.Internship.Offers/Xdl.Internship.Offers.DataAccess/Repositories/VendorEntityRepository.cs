using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
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
        Task<VendorEntity> FindByIdAsync(ObjectId id, CancellationToken cancellationToken = default);

        Task<VendorEntity> FindOneByLocationAsync(double[] location, CancellationToken cancellationToken = default);

        Task<ICollection<VendorEntity>> FindActiveAsync(CancellationToken cancellationToken = default);

        Task<ICollection<VendorEntity>> FindByCityAsync(ObjectId cityId, bool onlyActive, CancellationToken cancellationToken = default);

        Task<ICollection<VendorEntity>> FindByVendorId(ObjectId vendorId, CancellationToken cancellationToken = default);

        // CREATE
        Task InsertOneAsync(VendorEntity vendorEntity, CancellationToken cancellationToken = default);

        // UPDATE
        Task ReplaceOneAsync(VendorEntity vendorEntity, CancellationToken cancellationToken = default);
    }

    public class VendorEntityRepository : MongoRepositoryBase<VendorEntity>, IVendorEntityRepository
    {
        public VendorEntityRepository(ICollectionProvider collectionProvider)
            : base(collectionProvider)
        {
        }

        // READ
        public override Task<VendorEntity> FindByIdAsync(ObjectId id, CancellationToken cancellationToken = default)
        {
            return base.FindByIdAsync(id, cancellationToken);
        }

        public Task<VendorEntity> FindOneByLocationAsync(double[] location, CancellationToken cancellationToken = default)
        {
            // Expression<Func<VendorEntity, bool>> filter = (v) => v.Location.SequenceEqual(location);
            Expression<Func<VendorEntity, bool>> filter = (v) => v.Location[0] == location[0] && v.Location[1] == location[1];
            return FindOneAsync(filter, cancellationToken);
        }

        public Task<ICollection<VendorEntity>> FindActiveAsync(CancellationToken cancellationToken = default)
        {
            Expression<Func<VendorEntity, bool>> filter = (v) => v.IsActive == true;
            return FindAsync(filter, cancellationToken);
        }

        public Task<ICollection<VendorEntity>> FindByCityAsync(ObjectId cityId, bool onlyActive, CancellationToken cancellationToken = default)
        {
            Expression<Func<VendorEntity, bool>> filter = (v) => v.Adress.CityId == cityId && (!onlyActive || v.IsActive);
            return FindAsync(filter, cancellationToken);
        }

        public Task<ICollection<VendorEntity>> FindByVendorId(ObjectId vendorId, CancellationToken cancellationToken = default)
        {
            Expression<Func<VendorEntity, bool>> filter = (v) => v.VendorId == vendorId;
            return FindAsync(filter, cancellationToken);
        }

        // CREATE
        public override Task InsertOneAsync(VendorEntity vendorEntity, CancellationToken cancellationToken = default)
        {
            return base.InsertOneAsync(vendorEntity, cancellationToken);
        }

        // UPDATE
        public override Task ReplaceOneAsync(VendorEntity vendorEntity, CancellationToken cancellationToken = default)
        {
            return base.ReplaceOneAsync(vendorEntity, cancellationToken);
        }
    }
}
