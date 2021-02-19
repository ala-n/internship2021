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
    public class UserRepository : MongoRepositoryBase<User>, IUserRepository
    {
        public UserRepository(ICollectionProvider collectionProvider)
            : base(collectionProvider)
        {
        }

        public async Task<User> FindUserByIdAsync(ObjectId id, CancellationToken cancellationToken = default)
        {
            return await FindByIdAsync(id, default);
        }

        public async Task<ICollection<User>> FindUsersAsync(Expression<Func<User, bool>> filterExpression, CancellationToken cancellationToken = default)
        {
            return await FindAsync(filterExpression, cancellationToken);
        }

        public async Task<User> LoginAsync(UserCredentials userCredentials, CancellationToken cancellationToken = default)
        {
            var user = await FindOneAsync(x => x.Login == userCredentials.Login && x.Password == userCredentials.Password, cancellationToken);
            if (user != null)
            {
                user.Password = null;
                return user;
            }

            return null;
        }
    }
}
