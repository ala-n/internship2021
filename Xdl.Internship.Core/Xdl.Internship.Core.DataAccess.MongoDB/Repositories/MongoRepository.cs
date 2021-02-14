using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Xdl.Internship.Core.Models.MongoDB;

namespace Xdl.Internship.Core.DataAccess.MongoDB
{
    public class MongoRepository<TDocument> : IMongoRepository<TDocument> where TDocument : IModelBase
    {
        private readonly Lazy<IMongoCollection<TDocument>> collectionAccessor;
        private readonly Lazy<IMongoClient> clientAccessor;
        private readonly FilterDefinitionBuilder<TDocument> fdb;
        private readonly IMongoDBSetting settings;
        private string DatabaseName { get; set; }
        public MongoRepository(IMongoDBSetting settings)
        {
            settings = settings ?? throw new ArgumentNullException(nameof(settings));
            this.settings = settings;

            clientAccessor = new Lazy<IMongoClient>(BuildClient, LazyThreadSafetyMode.ExecutionAndPublication);
            collectionAccessor = new Lazy<IMongoCollection<TDocument>>
                (clientAccessor.Value.GetDatabase(DatabaseName).GetCollection<TDocument>(GetCollectionName(typeof(TDocument))));
            fdb = new FilterDefinitionBuilder<TDocument>();
        }
        protected IMongoClient BuildClient()
        {
            DatabaseName = settings.DatabaseName;
            if (string.IsNullOrEmpty(DatabaseName))
                throw new ArgumentNullException(nameof(DatabaseName));

            var host = settings.HostKeyName;
            if (string.IsNullOrEmpty(host))
                throw new ArgumentNullException(nameof(host));
            var port = settings.PortKeyName;
            var client = new MongoClient(new MongoClientSettings
            {
                Server = new MongoServerAddress(host, int.Parse(port))
            });
            return client;
        }

        protected virtual string GetCollectionName(Type docType)
        {
            return $"{docType.Name}Collection";
        }

        public virtual Task<List<TDocument>> FilterByAsync(
             Expression<Func<TDocument, bool>> filterExpression, CancellationToken cancellationToken = default)
        {
            return collectionAccessor.Value.FindSync(filterExpression, null, cancellationToken).ToListAsync(cancellationToken);
        }

        public virtual Task<TDocument> FindFirstOrDefaultAsync(Expression<Func<TDocument, bool>> filterExpression, CancellationToken cancellationToken = default)
        {
            return collectionAccessor.Value.Find(filterExpression).FirstOrDefaultAsync(cancellationToken);
        }


        public virtual Task<TDocument> FindByIdAsync(ObjectId id, CancellationToken cancellationToken = default)
        {
            var filter = fdb.Eq(doc => doc.Id, id);
            return collectionAccessor.Value.Find(filter).SingleOrDefaultAsync(cancellationToken);

        }

        public virtual Task InsertOneAsync(TDocument document, CancellationToken cancellationToken = default)
        {
            return collectionAccessor.Value.InsertOneAsync(document, null, cancellationToken);
        }

        public virtual async Task InsertManyAsync(ICollection<TDocument> documents, CancellationToken cancellationToken = default)
        {
            await collectionAccessor.Value.InsertManyAsync(documents, null, cancellationToken);
        }

        public virtual async Task ReplaceOneAsync(TDocument document, CancellationToken cancellationToken = default)
        {
            var filter = fdb.Eq(doc => doc.Id, document.Id);
            await collectionAccessor.Value.FindOneAndReplaceAsync(filter, document, cancellationToken: cancellationToken);
        }

        public virtual Task DeleteOneAsync(Expression<Func<TDocument, bool>> filterExpression, CancellationToken cancellationToken = default)
        {
            return collectionAccessor.Value.FindOneAndDeleteAsync(filterExpression, cancellationToken: cancellationToken);
        }

        public virtual Task DeleteByIdAsync(ObjectId id, CancellationToken cancellationToken)
        {
            var filter = fdb.Eq(doc => doc.Id, id);
            return collectionAccessor.Value.FindOneAndDeleteAsync(filter, cancellationToken: cancellationToken);

        }
        public virtual Task DeleteManyAsync(Expression<Func<TDocument, bool>> filterExpression, CancellationToken cancellationToken = default)
        {
            return collectionAccessor.Value.DeleteManyAsync(filterExpression, cancellationToken);
        }

        public virtual async Task<ICollection<TDocument>> GetAsync(ObjectId id, CancellationToken cancellationToken = default)
        {
            var filter = fdb.Eq(doc => doc.Id, id);
            return await FindAsync(filter, null, cancellationToken);
        }

        public virtual async Task<ICollection<TDocument>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await FindAsync(fdb.Empty, null, cancellationToken);
        }

        protected async Task<ICollection<TDocument>> FindAsync(FilterDefinition<TDocument> filter, FindOptions<TDocument> options = null, CancellationToken cancellationToken = default)
        {
            var cursor = await collectionAccessor.Value.FindAsync(filter, options, cancellationToken);
            return await cursor.ToListAsync(cancellationToken);
        }
    }
}
