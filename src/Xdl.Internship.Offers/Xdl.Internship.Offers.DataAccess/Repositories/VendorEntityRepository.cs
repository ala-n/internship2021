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
    public class VendorEntityRepository : MongoRepositoryBase<VendorEntity>, IVendorEntityRepository
    {
        public VendorEntityRepository(ICollectionProvider collectionProvider)
            : base(collectionProvider)
        {
        }

        // READ
        public Task<VendorEntity> FindOneByLocationAsync(double[] location, CancellationToken cancellationToken = default)
        {
            // Expression<Func<VendorEntity, bool>> filter = (v) => v.Location.SequenceEqual(location);
            Expression<Func<VendorEntity, bool>> filter = (v) => v.Location[0] == location[0] && v.Location[1] == location[1];
            return FindOneAsync(filter, cancellationToken);
        }

        public Task<ICollection<VendorEntity>> FindAsync(bool includeInactive, CancellationToken cancellationToken = default)
        {
            Expression<Func<VendorEntity, bool>> filter = (v) => includeInactive || v.IsActive == true;
            return FindAsync(filter, cancellationToken);
        }

        public Task<ICollection<VendorEntity>> FindByCityAsync(ObjectId cityId, bool onlyActive, CancellationToken cancellationToken = default)
        {
            Expression<Func<VendorEntity, bool>> filter = (v) => v.Adress.CityId == cityId && (!onlyActive || v.IsActive);
            return FindAsync(filter, cancellationToken);
        }

        public Task<ICollection<VendorEntity>> FindByVendorIdAsync(ObjectId vendorId, bool onlyActive, CancellationToken cancellationToken = default)
        {
            Expression<Func<VendorEntity, bool>> filter = (v) => v.VendorId == vendorId && (!onlyActive || v.IsActive == true);
            return FindAsync(filter, cancellationToken);
        }
    }
}
