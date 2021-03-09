using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Xdl.Internship.Offers.DataAccess.Interfaces;
using Xdl.Internship.Offers.SDK.FavoriteOfferDTOs;

namespace Xdl.Internship.Offers.Handlers.FavoriteOffer
{
    public class GetFavoriteUserOffersHandler : IRequestHandler<GetFavoriteUserOffersRequest, FavoriteOfferDTO>
    {
        private readonly IFavoriteOfferRepository _favoriteOfferRepository;
        private readonly IMapper _mapper;

        public GetFavoriteUserOffersHandler(IFavoriteOfferRepository favoriteOfferRepository, IMapper mapper)
        {
            _favoriteOfferRepository = favoriteOfferRepository;
            _mapper = mapper;
        }

        public async Task<FavoriteOfferDTO> Handle(GetFavoriteUserOffersRequest request, CancellationToken cancellationToken)
        {
            return _mapper.Map<FavoriteOfferDTO>(await _favoriteOfferRepository.FindOneFavoriteUserOfferAsync(request.OfferId, request.UserId));
        }
    }
}
