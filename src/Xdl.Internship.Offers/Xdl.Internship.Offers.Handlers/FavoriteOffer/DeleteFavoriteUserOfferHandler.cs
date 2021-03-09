using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Xdl.Internship.Offers.DataAccess.Interfaces;

namespace Xdl.Internship.Offers.Handlers.FavoriteOffer
{
    public class DeleteFavoriteUserOfferHandler : IRequestHandler<DeleteFavoriteUserOfferRequest>
    {
        private readonly IFavoriteOfferRepository _favoriteOfferRepository;
        private readonly IMapper _mapper;

        public DeleteFavoriteUserOfferHandler(IFavoriteOfferRepository favoriteOfferRepository, IMapper mapper)
        {
            _favoriteOfferRepository = favoriteOfferRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteFavoriteUserOfferRequest request, CancellationToken cancellationToken)
        {
            await _favoriteOfferRepository.RemoveFavoriteUserOfferAsync(request.OfferId, request.UserId);
            return Unit.Value;
        }
    }
}
