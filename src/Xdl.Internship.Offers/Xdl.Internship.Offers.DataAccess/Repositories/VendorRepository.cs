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
    public class VendorRepository : MongoRepositoryBase<Vendor>, IVendorRepository
    {
        public VendorRepository(ICollectionProvider collectionProvider)
            : base(collectionProvider)
        {
        }

        public Task<ICollection<Vendor>> FindAsync(bool includeInactive, CancellationToken cancellationToken = default)
        {
            Expression<Func<Vendor, bool>> filter = (v) => includeInactive || v.IsActive == true;
            return FindAsync(filter, cancellationToken = default);
        }

        public Task<ICollection<Vendor>> FindByIdsAsync(ICollection<ObjectId> ids, CancellationToken cancellationToken = default)
        {
            Expression<Func<Vendor, bool>> filter = (v) => ids.Contains(v.Id);
            return FindAsync(filter, cancellationToken = default);
        }
    }
}
