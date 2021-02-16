using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using Xdl.Internship.Core.Models.MongoDB;

namespace Xdl.Internship.Core.DataAccess.MongoDB.Repositories
{
    public interface IMongoRepository<TDocument>
        where TDocument : IModelBase
    {
        Task<TDocument> FindByIdAsync(ObjectId id);

        Task<ICollection<TDocument>> FindAsync(FilterDefinition<TDocument> filter, CancellationToken cancellationToken = default);

        Task InsertOneAsync(TDocument document, CancellationToken cancellationToken = default);

        Task InsertManyAsync(ICollection<TDocument> documents, CancellationToken cancellationToken = default);

        Task ReplaceOneAsync(TDocument document, CancellationToken cancellationToken = default);

        Task DeleteOneAsync(Expression<Func<TDocument, bool>> filterExpression, CancellationToken cancellationToken = default);

        Task DeleteByIdAsync(ObjectId id, CancellationToken cancellationToken = default);

        Task DeleteManyAsync(Expression<Func<TDocument, bool>> filterExpression, CancellationToken cancellationToken = default);
    }
}
