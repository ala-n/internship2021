using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Bson;
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

        public Task<ICollection<Feedback>> FindAllFeedbacksAsync(ObjectId userId, CancellationToken cancellationToken = default)
        {
            Expression<Func<Feedback, bool>> filter = (v) => v.UserId == userId;
            return FindAsync(filter, cancellationToken);
        }

        public Task<Feedback> FindOneFeedbackAsync(ObjectId offerId, ObjectId userId, CancellationToken cancellationToken = default)
        {
            Expression<Func<Feedback, bool>> filter = (v) => v.UserId == userId && v.OfferId == offerId;
            return FindOneAsync(filter, cancellationToken);
        }

        public Task<Feedback> UpdateFeedbackAsync(ObjectId offerId, ObjectId userId, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
