using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Bson;
using Xdl.Internship.Authentication.DataAccess.Interfaces;
using Xdl.Internship.Authentication.DTOs;
using Xdl.Internship.Authentication.Models;
using Xdl.Internship.Core.DataAccess.MongoDB.CollectionProviders;
using Xdl.Internship.Core.DataAccess.MongoDB.Repositories;

namespace Xdl.Internship.Authentication.DataAccess
{
    public class UserRepository : MongoRepositoryBase<Models.User>, IUserRepository
    {
        public UserRepository(ICollectionProvider collectionProvider)
            : base(collectionProvider)
        {
        }

        public async Task<Models.User> FindOneUserByIdAsync(ObjectId objectId, CancellationToken cancellation = default)
        {
            return await FindByIdAsync(objectId, cancellation);
        }

        public async Task<Models.User> FindUserByIdAsync(ObjectId id, CancellationToken cancellationToken = default)
        {
            return await FindByIdAsync(id, default);
        }

        public async Task<ICollection<Models.User>> FindUsersAsync(Expression<Func<Models.User, bool>> filterExpression, CancellationToken cancellationToken = default)
        {
            return await FindAsync(filterExpression, cancellationToken);
        }

        public async Task<Models.User> LoginAsync(string login, string password, CancellationToken cancellationToken = default)
        {
            var user = await FindOneAsync(x => x.Login == login && x.Password == password, cancellationToken);
            return user;
        }
    }
}
