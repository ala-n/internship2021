namespace Xdl.Internship.Core.RabbitMQ
{
    public interface IRabbitMqPublisher
    {
        void Publish(byte[] body);
    }
}
