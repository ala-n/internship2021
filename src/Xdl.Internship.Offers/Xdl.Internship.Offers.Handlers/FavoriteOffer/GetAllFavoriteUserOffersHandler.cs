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
    public class GetAllFavoriteUserOffersHandler : IRequestHandler<GetAllFavoriteUserOffersRequest, ICollection<FavoriteOfferDTO>>
    {
        private readonly IFavoriteOfferRepository _favoriteOfferRepository;
        private readonly IMapper _mapper;

        public GetAllFavoriteUserOffersHandler(IFavoriteOfferRepository favoriteOfferRepository, IMapper mapper)
        {
            _favoriteOfferRepository = favoriteOfferRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<FavoriteOfferDTO>> Handle(GetAllFavoriteUserOffersRequest request, CancellationToken cancellationToken)
        {
            return _mapper.Map<ICollection<FavoriteOfferDTO>>(await _favoriteOfferRepository.FindAllFavoriteUserOffersAsync(request.OfferId, request.UserId));
        }
    }
}
