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
    public interface ICityRepository
    {
        Task<City> FindByIdAsync(ObjectId id, CancellationToken cancellationToken = default);

        Task<ICollection<City>> FindActiveAsync(CancellationToken cancellationToken = default);

        Task InsertOneAsync(City city, CancellationToken cancellationToken = default);

        Task ReplaceOneAsync(City city, CancellationToken cancellationToken = default);
    }

    public class CityRepository : MongoRepositoryBase<City>, ICityRepository
    {
        public CityRepository(ICollectionProvider collectionProvider)
            : base(collectionProvider)
        {
        }

        public Task<ICollection<City>> FindActiveAsync(CancellationToken cancellationToken = default)
        {
            Expression<Func<City, bool>> filter = (v) => v.IsActive == true;
            return FindAsync(filter, cancellationToken);
        }

        public override Task<City> FindByIdAsync(ObjectId id, CancellationToken cancellationToken = default)
        {
            return base.FindByIdAsync(id, cancellationToken);
        }

        public override Task InsertOneAsync(City city, CancellationToken cancellationToken = default)
        {
            return base.InsertOneAsync(city, cancellationToken);
        }

        public override Task ReplaceOneAsync(City city, CancellationToken cancellationToken = default)
        {
            return base.ReplaceOneAsync(city, cancellationToken);
        }
    }
}
