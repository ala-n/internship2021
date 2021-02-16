using System;
using MongoDB.Driver;
using Xdl.Internship.Core.DataAccess.MongoDB.ConnectionFactories;
using Xdl.Internship.Core.Models.MongoDB;

namespace Xdl.Internship.Core.DataAccess.MongoDB.CollectionProviders
{
    public class DefaultCollectionProvider : ICollectionProvider
    {
        private readonly IConnectionFactory _connectionFactory;

        public DefaultCollectionProvider(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory ?? throw new ArgumentNullException(nameof(connectionFactory));
        }

        public IMongoCollection<TDocument> GetCollection<TDocument>(string name = null)
            where TDocument : IModelBase
        {
            if (string.IsNullOrEmpty(name))
            {
                name = GetCollectionName(typeof(TDocument));
            }

            var db = _connectionFactory.GetDb();
            return db.GetCollection<TDocument>(name);
        }

        protected virtual string GetCollectionName(Type docType)
        {
            return $"{docType.Name}Collection";
        }
    }
}
