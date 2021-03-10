using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Bson;
using Xdl.Internship.Core.DataAccess.MongoDB.Repositories;
using Xdl.Internship.Offers.Models;

namespace Xdl.Internship.Offers.DataAccess.Interfaces
{
    public interface IFeedbackRepository : IMongoRepository<Feedback>
    {
        public Task<ICollection<Feedback>> FindAllFeedbacksAsync(ObjectId userId, CancellationToken cancellationToken = default);

        public Task<Feedback> FindOneFeedbackAsync(ObjectId offerId, ObjectId userId, CancellationToken cancellationToken = default);

        public Task<Feedback> UpdateFeedbackAsync(ObjectId offerId, ObjectId userId, CancellationToken cancellationToken = default);
    }
}
