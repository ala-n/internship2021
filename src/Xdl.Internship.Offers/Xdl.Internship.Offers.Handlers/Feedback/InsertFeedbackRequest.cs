using MediatR;
using MongoDB.Bson;
using Xdl.Internship.Offers.SDK.FeedbackDTOs;

namespace Xdl.Internship.Offers.Handlers.Feedback
{
    public class InsertFeedbackRequest : IRequest<FeedbackDTO>
    {
        public ObjectId OfferId { get; }

        public CreateFeedbackDTO FeedbackDTO { get; }

        public InsertFeedbackRequest(ObjectId offerId, CreateFeedbackDTO feedbackDTO)
        {
            FeedbackDTO = feedbackDTO;
            OfferId = offerId;
        }
    }
}
