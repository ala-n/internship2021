using MongoDB.Driver;

namespace Xdl.Internship.Core.DataAccess.MongoDB
{
    public interface IConnectionFactory
    {
        IMongoDatabase GetDb(string name = null);
    }
}
