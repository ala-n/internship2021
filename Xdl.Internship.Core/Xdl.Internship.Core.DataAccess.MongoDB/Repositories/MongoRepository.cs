using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using Xdl.Internship.Core.DataAccess.MongoDB.CollectionProviders;
using Xdl.Internship.Core.Models.MongoDB;

namespace Xdl.Internship.Core.DataAccess.MongoDB.Repositories
{
    public abstract class MongoRepository<TDocument> : IMongoRepository<TDocument>
        where TDocument : IModelBase
    {
        private readonly ICollectionProvider _collectionProvider;
        private readonly Lazy<IMongoCollection<TDocument>> _collectionAccessor;
        private readonly FilterDefinitionBuilder<TDocument> _fdb;

        public MongoRepository(ICollectionProvider collectionProvider)
        {
            _collectionProvider = collectionProvider ?? throw new ArgumentNullException(nameof(collectionProvider));
            _collectionAccessor = new Lazy<IMongoCollection<TDocument>>(() => _collectionProvider.GetCollection<TDocument>(), LazyThreadSafetyMode.ExecutionAndPublication);
            _fdb = new FilterDefinitionBuilder<TDocument>();
        }

        // Read
        public virtual Task<TDocument> FindByIdAsync(ObjectId id, CancellationToken cancellationToken = default)
        {
            var filter = _fdb.Eq(doc => doc.Id, id);
            return GetCollection().Find(filter).SingleOrDefaultAsync(cancellationToken);
        }

        public virtual Task<TDocument> FindOneAsync(Expression<Func<TDocument, bool>> filterExpression, CancellationToken cancellationToken = default)
        {
            return GetCollection().Find(filterExpression).SingleOrDefaultAsync(cancellationToken);
        }

        public virtual async Task<ICollection<TDocument>> FindAsync(Expression<Func<TDocument, bool>> filterExpression, CancellationToken cancellationToken = default)
        {
            return await GetCollection().Find(filterExpression, null).ToListAsync(cancellationToken);
        }

        // Create
        public virtual Task InsertOneAsync(TDocument document, CancellationToken cancellationToken = default)
        {
            return GetCollection().InsertOneAsync(document, null, cancellationToken);
        }

        public virtual Task InsertManyAsync(ICollection<TDocument> documents, CancellationToken cancellationToken = default)
        {
            return GetCollection().InsertManyAsync(documents, null, cancellationToken);
        }

        // Update (put)
        public virtual Task ReplaceOneAsync(TDocument document, CancellationToken cancellationToken = default)
        {
            var filter = _fdb.Eq(doc => doc.Id, document.Id);
            return GetCollection().FindOneAndReplaceAsync(filter, document, cancellationToken: cancellationToken);
        }

        // Delete
        public virtual Task DeleteOneAsync(Expression<Func<TDocument, bool>> filterExpression, CancellationToken cancellationToken = default)
        {
            return GetCollection().FindOneAndDeleteAsync(filterExpression, cancellationToken: cancellationToken);
        }

        public virtual Task DeleteByIdAsync(ObjectId id, CancellationToken cancellationToken)
        {
            var filter = _fdb.Eq(doc => doc.Id, id);
            return GetCollection().FindOneAndDeleteAsync(filter, cancellationToken: cancellationToken);
        }

        public virtual Task DeleteManyAsync(Expression<Func<TDocument, bool>> filterExpression, CancellationToken cancellationToken = default)
        {
            return GetCollection().DeleteManyAsync(filterExpression, cancellationToken);
        }

        // Service methods
        protected virtual IMongoCollection<TDocument> GetCollection()
        {
            return _collectionAccessor.Value;
        }
    }
}
