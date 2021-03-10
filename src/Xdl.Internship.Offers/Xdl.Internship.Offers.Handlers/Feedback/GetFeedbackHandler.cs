using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MongoDB.Bson;
using Xdl.Internship.Offers.DataAccess.Interfaces;
using Xdl.Internship.Offers.SDK.FeedbackDTOs;

namespace Xdl.Internship.Offers.Handlers.Feedback
{
    public class GetFeedbackHandler : IRequestHandler<GetFeedbackRequest, FeedbackDTO>
    {
        private readonly IFeedbackRepository _favoriteOfferRepository;
        private readonly IMapper _mapper;

        public GetFeedbackHandler(IFeedbackRepository favoriteOfferRepository, IMapper mapper)
        {
            _favoriteOfferRepository = favoriteOfferRepository;
            _mapper = mapper;
        }

        public async Task<FeedbackDTO> Handle(GetFeedbackRequest request, CancellationToken cancellationToken)
        {
            return _mapper.Map<FeedbackDTO>(await _favoriteOfferRepository.FindOneFeedbackAsync(new ObjectId(request.OfferId), new ObjectId(request.UserId)));
        }
    }
}
