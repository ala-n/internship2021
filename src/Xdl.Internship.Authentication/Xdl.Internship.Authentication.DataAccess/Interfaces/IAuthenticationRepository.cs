using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Bson;
using Xdl.Internship.Authentication.DTOs;
using Xdl.Internship.Authentication.Models;

namespace Xdl.Internship.Authentication.DataAccess.Interfaces
{
    public interface IAuthenticationRepository
    {
        Task<User> FindUserByIdAsync(ObjectId id, CancellationToken cancellationToken = default);

        Task<ICollection<User>> FindUsersAsync(Expression<Func<User, bool>> filterExpression, CancellationToken cancellationToken = default);

        Task<User> LoginAsync(LoginAuth loginAuth, CancellationToken cancellationToken = default);
    }
}
