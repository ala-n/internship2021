using System;
using System.Threading;
using MongoDB.Driver;

namespace Xdl.Internship.Core.DataAccess.MongoDB.ConnectionFactories
{
    public class DefaultConnectionFactory : IConnectionFactory
    {
        private readonly IMongoDBSetting settings;
        private readonly Lazy<IMongoClient> clientAccessor;

        public DefaultConnectionFactory(IMongoDBSetting settings)
        {
            this.settings = settings ?? throw new ArgumentNullException(nameof(settings));

            clientAccessor = new Lazy<IMongoClient>(BuildClient, LazyThreadSafetyMode.ExecutionAndPublication);
        }

        public IMongoDatabase GetDb(string name = null)
        {
            if (string.IsNullOrEmpty(name))
            {
                // Setting default DB NAME 
                name = settings.DatabaseName;
            }
            return clientAccessor.Value.GetDatabase(name);
        }

        private IMongoClient BuildClient()
        {
            if (string.IsNullOrEmpty(settings.DatabaseName))
                throw new ArgumentNullException(nameof(settings.DatabaseName));

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
    }
}
