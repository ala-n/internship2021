using MongoDB.Driver;

namespace Xdl.Internship.Core.DataAccess.MongoDB
{
    public interface ICollectionProvider
    {
        IMongoCollection<TDocument> GetCollection<TDocument>(string name = null)
            where TDocument : class;
    }
}
