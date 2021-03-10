using MediatR;
using MongoDB.Bson;
using Xdl.Internship.Offers.SDK.FeedbackDTOs;

namespace Xdl.Internship.Offers.Handlers.Feedback
{
    public class AddFeedbackRequest : IRequest<FeedbackDTO>
    {
        public AddFeedbackRequest(CreateFeedback feedback, string userId)
        {
            if (feedback.Rate > 0 && feedback.Rate <= 5)
            {
            Feedback = feedback;
            UserId = userId;
            }
            else
            {
                throw new System.ArgumentOutOfRangeException();
            }
        }

        public CreateFeedback Feedback { get; }

        public string UserId { get; }
    }
}
