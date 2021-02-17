using System;
using System.Threading;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Xdl.Internship.Core.DataAccess.MongoDB.Settings;

namespace Xdl.Internship.Core.DataAccess.MongoDB.ConnectionFactories
{
    public class DefaultConnectionFactory : IConnectionFactory
    {
        private readonly MongoDBSetting _settings;
        private readonly Lazy<IMongoClient> _clientAccessor;

        public DefaultConnectionFactory(IOptions<MongoDBSetting> settings)
        {
            if (settings == null || settings.Value == null)
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
                throw new ArgumentNullException(nameof(_settings.DatabaseName));
            }

            return _clientAccessor.Value.GetDatabase(_settings.DatabaseName);
        }

        private IMongoClient BuildClient()
        {
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
