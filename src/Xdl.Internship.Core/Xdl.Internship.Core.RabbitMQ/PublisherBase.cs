using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using System;
using System.Threading;

namespace Xdl.Internship.Core.RabbitMQ
{
    public abstract class PublisherBase : IRabbitMqPublisher, IDisposable
    {
        private Lazy<IModel> _modelAccessor;

        private string _hostname;
        private string _username;
        private string _password;

        protected PublisherBase(IOptions<RabbitMQConfiguration> rabbitMqOptions)
        {
            _hostname = rabbitMqOptions.Value.Hostname;
            _username = rabbitMqOptions.Value.UserName;
            _password = rabbitMqOptions.Value.Password;

            _modelAccessor = new Lazy<IModel>(BuildModel, LazyThreadSafetyMode.ExecutionAndPublication);
        }

        public void Publish(byte[] body)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            if (_modelAccessor.IsValueCreated)
            {
                _modelAccessor.Value.Dispose();
            }
        }

        protected abstract void DeclareQueue(IModel model);

        private IModel BuildModel()
        {
            var factory = new ConnectionFactory
            {
                HostName = _hostname,
                UserName = _username,
                Password = _password,
            };
            var connection = factory.CreateConnection();

            IModel channel = connection.CreateModel();
            DeclareQueue(channel);

            return channel;
        }
    }
}
