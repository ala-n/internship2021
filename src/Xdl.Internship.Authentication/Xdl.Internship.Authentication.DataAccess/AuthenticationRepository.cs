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
    public class AuthenticationRepository : MongoRepositoryBase<User>, IAuthenticationRepository
    {
        public AuthenticationRepository(ICollectionProvider collectionProvider)
            : base(collectionProvider)
        {
        }

        public Task<User> FindUserByIdAsync(ObjectId id, CancellationToken cancellationToken = default)
        {
            return FindByIdAsync(id, default);
        }

        public Task<ICollection<User>> FindUsersAsync(Expression<Func<User, bool>> filterExpression, CancellationToken cancellationToken = default)
        {
            return FindAsync(filterExpression, cancellationToken);
        }

        public Task<User> LoginAsync(LoginAuth loginAuth, CancellationToken cancellationToken = default)
        {
            var user = FindOneAsync(x => x.Login == loginAuth.Login && x.Password == loginAuth.Password, cancellationToken);
            if (user.Result != null)
            {
                return user;
            }

            return null;
        }
    }
}
