using System;
using System.Threading;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;

namespace Xdl.Internship.Core.RabbitMQ
{
    public abstract class PublisherBase : IRabbitMqPublisher, IDisposable
    {
        protected Lazy<IModel> _modelAccessor;

        private readonly string _hostname;
        private readonly string _username;
        private readonly string _password;
        private readonly string _queueName;

        protected PublisherBase(IOptions<RabbitMqConfiguration> rabbitMqOptions)
        {
            _hostname = rabbitMqOptions.Value.Hostname;
            _username = rabbitMqOptions.Value.UserName;
            _password = rabbitMqOptions.Value.Password;
            _queueName = rabbitMqOptions.Value.QueueName;

            _modelAccessor = new Lazy<IModel>(BuildModel, LazyThreadSafetyMode.ExecutionAndPublication);
        }

        public void Dispose()
        {
            if (_modelAccessor.IsValueCreated)
            {
                _modelAccessor.Value.Dispose();
            }
        }

        public void Publish(byte[] body)
        {
        }

        protected abstract void DeclareQuee(IModel model);

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
            DeclareQuee(channel);

            return channel;
        }
    }
}
