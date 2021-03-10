using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MongoDB.Bson;
using Xdl.Internship.Offers.DataAccess.Interfaces;
using Xdl.Internship.Offers.SDK.FeedbackDTOs;

namespace Xdl.Internship.Offers.Handlers.Feedback
{
    public class GetAllFeedbacksHandler : IRequestHandler<GetAllFeedbacksRequest, ICollection<FeedbackDTO>>
    {
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly IMapper _mapper;

        public GetAllFeedbacksHandler(IFeedbackRepository feedbackRepository, IMapper mapper)
        {
            _feedbackRepository = feedbackRepository ?? throw new System.ArgumentNullException(nameof(feedbackRepository));
            _mapper = mapper ?? throw new System.ArgumentNullException(nameof(mapper));
        }

        public async Task<ICollection<FeedbackDTO>> Handle(GetAllFeedbacksRequest request, CancellationToken cancellationToken)
        {
            return _mapper.Map<ICollection<FeedbackDTO>>(await _feedbackRepository.FindAllFeedbacksAsync(new ObjectId(request.UserId)));
        }
    }
}
