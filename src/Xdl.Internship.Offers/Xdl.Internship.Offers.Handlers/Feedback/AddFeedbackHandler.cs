using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MongoDB.Bson;
using Xdl.Internship.Offers.DataAccess.Interfaces;
using Xdl.Internship.Offers.Handlers.Offer;
using Xdl.Internship.Offers.SDK.FeedbackDTOs;

namespace Xdl.Internship.Offers.Handlers.Feedback
{
    public class AddFeedbackHandler : IRequestHandler<AddFeedbackRequest, FeedbackDTO>
    {
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public AddFeedbackHandler(IFeedbackRepository feedbackRepository, IMapper mapper, IMediator mediator)
        {
            _feedbackRepository = feedbackRepository ?? throw new System.ArgumentNullException(nameof(feedbackRepository));
            _mapper = mapper ?? throw new System.ArgumentNullException(nameof(mapper));
            _mediator = mediator;
        }

        public async Task<FeedbackDTO> Handle(AddFeedbackRequest request, CancellationToken cancellationToken)
        {
            var feedback = _mapper.Map<Models.Feedback>(request.Feedback);
            feedback.UserId = new ObjectId(request.UserId);
            feedback.CreatedAt = DateTimeOffset.Now;
            feedback.CreatedBy = request.UserId;
            feedback.UpdatedAt = DateTimeOffset.Now;
            feedback.UpdatedBy = request.UserId;
            await _feedbackRepository.InsertOneAsync(feedback);
            var updateOfferRate = await _mediator.Send(new UpdateOfferRateRequest(feedback.OfferId, feedback.Rate));
            if (updateOfferRate == false)
            {
                throw new NullReferenceException();
            }

            return _mapper.Map<FeedbackDTO>(await _feedbackRepository.FindByIdAsync(feedback.Id));
        }
    }
}
