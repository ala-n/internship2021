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
    public class CityRepository : MongoRepositoryBase<City>, ICityRepository
    {
        public CityRepository(ICollectionProvider collectionProvider)
            : base(collectionProvider)
        {
        }

        public Task<ICollection<City>> FindAsync(bool includeInactive, CancellationToken cancellationToken = default)
        {
            Expression<Func<City, bool>> filter = (v) => includeInactive || v.IsActive == true;
            return FindAsync(filter, cancellationToken);
        }
    }
}
