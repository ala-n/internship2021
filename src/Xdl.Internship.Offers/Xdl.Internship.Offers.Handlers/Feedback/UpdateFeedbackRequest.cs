using MediatR;
using Xdl.Internship.Offers.SDK.FeedbackDTOs;

namespace Xdl.Internship.Offers.Handlers.Feedback
{
    public class UpdateFeedbackRequest : IRequest<FeedbackDTO>
    {
        public UpdateFeedbackRequest(string offerId, int rate, string userId)
        {
            OfferId = offerId;
            Rate = rate;
            UserId = userId;
        }

        public string OfferId { get; }

        public int Rate { get; }

        public string UserId { get; }
    }
}
