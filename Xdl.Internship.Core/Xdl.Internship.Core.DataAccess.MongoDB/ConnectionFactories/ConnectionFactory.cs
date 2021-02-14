using System;
using System.Threading;
using MongoDB.Driver;

namespace Xdl.Internship.Core.DataAccess.MongoDB.ConnectionFactories
{
    public class DefaultConnectionFactory : IConnectionFactory
    {
        private readonly IMongoDBSetting _settings;
        private readonly Lazy<IMongoClient> _clientAccessor;

        public DefaultConnectionFactory(IMongoDBSetting settings)
        {
            _settings = settings ?? throw new ArgumentNullException(nameof(settings));

            _clientAccessor = new Lazy<IMongoClient>(BuildClient, LazyThreadSafetyMode.ExecutionAndPublication);
        }

        public IMongoDatabase GetDb(string name = null)
        {
            if (string.IsNullOrEmpty(name))
            {
                // Setting default DB NAME
                name = _settings.DatabaseName;
            }

            return _clientAccessor.Value.GetDatabase(name);
        }

        private IMongoClient BuildClient()
        {
            if (string.IsNullOrEmpty(_settings.DatabaseName))
            {
                throw new ArgumentNullException(nameof(_settings.DatabaseName));
            }

            var host = _settings.HostKeyName;
            if (string.IsNullOrEmpty(host))
            {
                throw new ArgumentNullException(nameof(host));
            }

            var port = _settings.PortKeyName;
            var client = new MongoClient(new MongoClientSettings
            {
                Server = new MongoServerAddress(host, int.Parse(port)),
            });
            return client;
        }
    }
}
