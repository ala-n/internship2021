using System;
using System.Threading;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;

namespace Xdl.Internship.Scheduler.ServiceHost.Rabbit
{
    public abstract class PublisherBase : IRabbitMqPublisher, IDisposable
    {
        private Lazy<IModel> _modelAccessor;

        private string _hostname;
        private string _username;
        private string _password;

        protected PublisherBase(IOptions<RabbitMqConfiguration> rabbitMqOptions)
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
