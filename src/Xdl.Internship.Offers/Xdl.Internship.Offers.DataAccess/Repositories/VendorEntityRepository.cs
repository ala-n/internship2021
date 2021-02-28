using System;
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
        Task<ICollection<VendorEntity>> FindByCityAsync(ObjectId cityId, bool onlyActive);

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

        public Task<ICollection<VendorEntity>> FindByCityAsync(ObjectId cityId, bool onlyActive)
        {
            Expression<Func<VendorEntity, bool>> filter = (v) => v.Adress.CityId == cityId && (!onlyActive || v.IsActive);
            return FindAsync(filter);
        }
    }
}
