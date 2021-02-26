using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
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

        public async Task<ICollection<Vendor>> FindActiveAsync()
        {
            Expression<Func<Vendor, bool>> filter = (v) => v.IsActive == true;
            return await FindAsync(filter);
        }

        public Task<Vendor> GetAllVendors()
        {
            throw new ArgumentException();
        }
    }
}
