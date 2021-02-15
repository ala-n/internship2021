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
            _collectionProvider = collectionProvider;
            _collectionAccessor = new Lazy<IMongoCollection<TDocument>>(GetCollection, LazyThreadSafetyMode.ExecutionAndPublication);
            _fdb = new FilterDefinitionBuilder<TDocument>();
        }

        public virtual Task<List<TDocument>> FilterByAsync(
             Expression<Func<TDocument, bool>> filterExpression, CancellationToken cancellationToken = default)
        {
            return _collectionAccessor.Value.FindSync(filterExpression, null, cancellationToken).ToListAsync(cancellationToken);
        }

        public virtual Task<TDocument> TryFindOneAsync(Expression<Func<TDocument, bool>> filterExpression, CancellationToken cancellationToken = default)
        {
            return _collectionAccessor.Value.Find(filterExpression).FirstOrDefaultAsync(cancellationToken);
        }

        public virtual Task<TDocument> FindByIdAsync(ObjectId id, CancellationToken cancellationToken = default)
        {
            var filter = _fdb.Eq(doc => doc.Id, id);
            return _collectionAccessor.Value.Find(filter).SingleOrDefaultAsync(cancellationToken);
        }

        public virtual Task InsertOneAsync(TDocument document, CancellationToken cancellationToken = default)
        {
            return _collectionAccessor.Value.InsertOneAsync(document, null, cancellationToken);
        }

        public virtual async Task InsertManyAsync(ICollection<TDocument> documents, CancellationToken cancellationToken = default)
        {
            await _collectionAccessor.Value.InsertManyAsync(documents, null, cancellationToken);
        }

        public virtual async Task ReplaceOneAsync(TDocument document, CancellationToken cancellationToken = default)
        {
            var filter = _fdb.Eq(doc => doc.Id, document.Id);
            await _collectionAccessor.Value.FindOneAndReplaceAsync(filter, document, cancellationToken: cancellationToken);
        }

        public virtual Task DeleteOneAsync(Expression<Func<TDocument, bool>> filterExpression, CancellationToken cancellationToken = default)
        {
            return _collectionAccessor.Value.FindOneAndDeleteAsync(filterExpression, cancellationToken: cancellationToken);
        }

        public virtual Task DeleteByIdAsync(ObjectId id, CancellationToken cancellationToken)
        {
            var filter = _fdb.Eq(doc => doc.Id, id);
            return _collectionAccessor.Value.FindOneAndDeleteAsync(filter, cancellationToken: cancellationToken);
        }

        public virtual Task DeleteManyAsync(Expression<Func<TDocument, bool>> filterExpression, CancellationToken cancellationToken = default)
        {
            return _collectionAccessor.Value.DeleteManyAsync(filterExpression, cancellationToken);
        }

        public virtual async Task<ICollection<TDocument>> GetAsync(ObjectId id, CancellationToken cancellationToken = default)
        {
            var filter = _fdb.Eq(doc => doc.Id, id);
            return await FindAsync(filter, null, cancellationToken);
        }

        public virtual async Task<ICollection<TDocument>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await FindAsync(_fdb.Empty, null, cancellationToken);
        }

        protected async Task<ICollection<TDocument>> FindAsync(FilterDefinition<TDocument> filter, FindOptions<TDocument> options = null, CancellationToken cancellationToken = default)
        {
            var cursor = await _collectionAccessor.Value.FindAsync(filter, options, cancellationToken);
            return await cursor.ToListAsync(cancellationToken);
        }

        protected virtual IMongoCollection<TDocument> GetCollection()
        {
            return _collectionProvider.GetCollection<TDocument>();
        }
    }
}
