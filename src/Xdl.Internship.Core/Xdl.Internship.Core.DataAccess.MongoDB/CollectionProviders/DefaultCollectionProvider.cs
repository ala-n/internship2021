using System;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using Xdl.Internship.Core.DataAccess.MongoDB.ConnectionFactories;
using Xdl.Internship.Core.Models.MongoDB;

namespace Xdl.Internship.Core.DataAccess.MongoDB.CollectionProviders
{
    public class DefaultCollectionProvider : ICollectionProvider
    {
        private readonly IConnectionFactory _connectionFactory;
        private readonly ILogger<DefaultCollectionProvider> _logger;

        public DefaultCollectionProvider(IConnectionFactory connectionFactory, ILogger<DefaultCollectionProvider> logger)
        {
            _connectionFactory = connectionFactory ?? throw new ArgumentNullException(nameof(connectionFactory));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public IMongoCollection<TDocument> GetCollection<TDocument>(string name = null)
            where TDocument : IModel
        {
            if (string.IsNullOrEmpty(name))
            {
                name = GetCollectionName(typeof(TDocument));
            }

            _logger.LogDebug($"Collection name is '{name}' for document type '{typeof(TDocument)}'");

            var db = _connectionFactory.GetDb();
            return db.GetCollection<TDocument>(name);
        }

        protected virtual string GetCollectionName(Type docType)
        {
            return $"{docType.Name}Collection";
        }
    }
}
