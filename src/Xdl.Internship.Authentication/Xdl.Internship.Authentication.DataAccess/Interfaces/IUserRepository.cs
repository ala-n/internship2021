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
    public interface IUserRepository
    {
        Task<Models.User> FindUserByIdAsync(ObjectId id, CancellationToken cancellationToken = default);

        Task<ICollection<Models.User>> FindUsersAsync(Expression<Func<Models.User, bool>> filterExpression, CancellationToken cancellationToken = default);

        Task<Models.User> LoginAsync(string login, string password, CancellationToken cancellationToken = default);
    }
}
