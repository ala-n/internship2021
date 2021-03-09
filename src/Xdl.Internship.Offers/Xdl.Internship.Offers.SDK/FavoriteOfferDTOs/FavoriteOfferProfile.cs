using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using MongoDB.Bson;
using Xdl.Internship.Offers.Models;

namespace Xdl.Internship.Offers.SDK.FavoriteOfferDTOs
{
    public class FavoriteOfferProfile : Profile
    {
        public FavoriteOfferProfile()
        {
            CreateMap<FavoriteOffer, FavoriteOfferDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()))
                .ForMember(dest => dest.OfferId, opt => opt.MapFrom(src => src.OfferId.ToString()));

            CreateMap<FavoriteOfferDTO, FavoriteOffer>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => new ObjectId(src.Id)))
                .ForMember(dest => dest.OfferId, opt => opt.MapFrom(src => new ObjectId(src.OfferId)));
        }
    }
}
