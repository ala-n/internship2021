using MediatR;
using Xdl.Internship.Offers.SDK.FeedbackDTOs;

namespace Xdl.Internship.Offers.Handlers.Feedback
{
    public class GetFeedbackRequest : IRequest<FeedbackDTO>
    {
        public GetFeedbackRequest(string offerId, string userId)
        {
            OfferId = offerId;
            UserId = userId;
        }

        public string OfferId { get; }

        public string UserId { get; }
    }
}
