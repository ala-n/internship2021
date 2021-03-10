using System.Collections.Generic;
using MediatR;
using Xdl.Internship.Offers.SDK.FeedbackDTOs;

namespace Xdl.Internship.Offers.Handlers.Feedback
{
    public class GetAllFeedbacksRequest : IRequest<ICollection<FeedbackDTO>>
    {
        public GetAllFeedbacksRequest(string userId)
        {
            UserId = userId;
        }

        public string UserId { get; }
    }
}
