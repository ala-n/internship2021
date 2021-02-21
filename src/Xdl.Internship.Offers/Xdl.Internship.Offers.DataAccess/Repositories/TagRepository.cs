using Xdl.Internship.Core.DataAccess.MongoDB.CollectionProviders;
using Xdl.Internship.Core.DataAccess.MongoDB.Repositories;
using Xdl.Internship.Offers.Models;

namespace Xdl.Internship.Offers.DataAccess.Repositories
{
    public class TagRepository : MongoRepositoryBase<Tag>
    {
        public TagRepository(ICollectionProvider collectionProvider)
            : base(collectionProvider)
        {
        }
    }
}
