using MongoDB.Driver;
using Xdl.Internship.Core.Models.MongoDB;

namespace Xdl.Internship.Core.DataAccess.MongoDB.CollectionProviders
{
    public interface ICollectionProvider
    {
        IMongoCollection<TDocument> GetCollection<TDocument>(string name = null)
            where TDocument : IModel;
    }
}
