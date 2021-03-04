using System.Threading;
using System.Threading.Tasks;
using Xdl.Internship.Core.DataAccess.MongoDB.CollectionProviders;
using Xdl.Internship.Core.DataAccess.MongoDB.Repositories;
using Xdl.Internship.Offers.DataAccess.Interfaces;
using Xdl.Internship.Offers.Models;

namespace Xdl.Internship.Offers.DataAccess.Repositories
{
    public class FeedbackRepository : MongoRepositoryBase<Feedback>, IFeedbackRepository
    {
        public FeedbackRepository(ICollectionProvider collectionProvider)
            : base(collectionProvider)
        {
        }

        public Task InsertFeedbackAsync(Feedback feedback, CancellationToken cancellationToken = default)
        {
            return InsertOneAsync(feedback, cancellationToken);
        }
    }
}
