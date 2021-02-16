using System;
using System.Threading;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Xdl.Internship.Core.DataAccess.MongoDB.Settings;

namespace Xdl.Internship.Core.DataAccess.MongoDB.ConnectionFactories
{
    public class DefaultConnectionFactory : IConnectionFactory
    {
        private readonly IMongoDBSetting _settings;
        private readonly Lazy<IMongoClient> _clientAccessor;

        public DefaultConnectionFactory(IOptions<IMongoDBSetting> settings)
        {
            if (settings.Equals(null) || settings.Value.Equals(null))
            {
                throw new ArgumentNullException(nameof(settings));
            }

            _settings = settings.Value;
            _clientAccessor = new Lazy<IMongoClient>(BuildClient, LazyThreadSafetyMode.ExecutionAndPublication);
        }

        public IMongoDatabase GetDb()
        {
            if (string.IsNullOrEmpty(_settings.DatabaseName))
            {
                throw new ArgumentException(nameof(_settings.DatabaseName));
            }

            return _clientAccessor.Value.GetDatabase(_settings.DatabaseName);
        }

        private IMongoClient BuildClient()
        {
            if (string.IsNullOrEmpty(_settings.DatabaseName))
            {
                throw new ArgumentNullException(nameof(_settings.DatabaseName));
            }

            var host = _settings.Host;
            if (string.IsNullOrEmpty(host))
            {
                throw new ArgumentNullException(nameof(host));
            }

            var port = _settings.Port;
            var client = new MongoClient(new MongoClientSettings
            {
                Server = new MongoServerAddress(host, int.Parse(port)),
            });
            return client;
        }
    }
}
