using MongoDB.Driver;

namespace Xdl.Internship.Core.DataAccess.MongoDB.ConnectionFactories
{
    public interface IConnectionFactory
    {
        IMongoDatabase GetDb(string name = null);
    }
}
