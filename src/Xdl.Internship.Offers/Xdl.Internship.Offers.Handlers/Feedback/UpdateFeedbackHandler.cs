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
    public class UpdateFeedbackHandler : IRequestHandler<UpdateFeedbackRequest, FeedbackDTO>
    {
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public UpdateFeedbackHandler(IFeedbackRepository feedbackRepository, IMapper mapper, IMediator mediator)
        {
            _feedbackRepository = feedbackRepository ?? throw new ArgumentNullException(nameof(feedbackRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<FeedbackDTO> Handle(UpdateFeedbackRequest request, CancellationToken cancellationToken)
        {
            var feedback = await _feedbackRepository.FindOneFeedbackAsync(new ObjectId(request.OfferId), new ObjectId(request.UserId));
            feedback.Rate = request.Rate;
            await _feedbackRepository.ReplaceOneAsync(feedback);
            var updateOfferRate = await _mediator.Send(new UpdateOfferRateRequest(feedback.OfferId, feedback.Rate));
            if (updateOfferRate == false)
            {
                throw new NullReferenceException();
            }

            return _mapper.Map<FeedbackDTO>(feedback);
        }
    }
}
