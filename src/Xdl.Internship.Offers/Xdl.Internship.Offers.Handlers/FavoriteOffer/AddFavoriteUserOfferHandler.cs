using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MongoDB.Bson;
using Xdl.Internship.Offers.DataAccess.Interfaces;
using Xdl.Internship.Offers.SDK.FavoriteOfferDTOs;

namespace Xdl.Internship.Offers.Handlers.FavoriteOffer
{
    public class AddFavoriteUserOfferHandler : IRequestHandler<AddFavoriteUserOfferRequest, FavoriteOfferDTO>
    {
        private readonly IFavoriteOfferRepository _favoriteOfferRepository;
        private readonly IMapper _mapper;

        public AddFavoriteUserOfferHandler(IFavoriteOfferRepository favoriteOfferRepository, IMapper mapper)
        {
            _favoriteOfferRepository = favoriteOfferRepository;
            _mapper = mapper;
        }

        public async Task<FavoriteOfferDTO> Handle(AddFavoriteUserOfferRequest request, CancellationToken cancellationToken)
        {
            Models.FavoriteOffer favoriteOffer = new Models.FavoriteOffer
            {
                OfferId = new ObjectId(request.OfferId),
                UserId = new ObjectId(request.UserId),
                CreatedBy = request.UserId,
                CreatedAt = DateTimeOffset.Now,
            };
            await _favoriteOfferRepository.InsertOneAsync(favoriteOffer);
            return _mapper.Map<FavoriteOfferDTO>(await _favoriteOfferRepository.FindByIdAsync(favoriteOffer.Id));
        }
    }
}
