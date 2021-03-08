using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Xdl.Internship.Offers.Models;

namespace Xdl.Internship.Offers.SDK.FavoriteOfferDTOs
{
    public class FavoriteOfferProfile : Profile
    {
        public FavoriteOfferProfile()
        {
            CreateMap<FavoriteOffer, FavoriteOfferDTO>()
                .ForMember(dest => dest.OfferId, opt => opt.MapFrom(src => src.OfferId.ToString()))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId.ToString()));
        }
    }
}
