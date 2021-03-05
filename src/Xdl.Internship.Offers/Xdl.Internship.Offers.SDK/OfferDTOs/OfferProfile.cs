using System;
using System.Linq;
using AutoMapper;
using MongoDB.Bson;
using Xdl.Internship.Offers.Models;

namespace Xdl.Internship.Offers.SDK.OfferDTOs
{
    public class OfferProfile : Profile
    {
        public OfferProfile()
        {
            CreateMap<Offer, OfferDTO>();

            CreateMap<Offer, OfferForListDTO>()
                .ReverseMap();

            CreateMap<Offer, OfferMainDTO>()
                .ReverseMap();

            CreateMap<CreateOfferDTO, Offer>()
                .ForMember(dest => dest.Rate, opt => opt.MapFrom(src => 0))
                .ForMember(dest => dest.NumberOfUses, opt => opt.MapFrom(src => 0))
                .ForMember(dest => dest.NumberOfViews, opt => opt.MapFrom(src => 0))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTimeOffset.Now));

            CreateMap<UpdateOfferDTO, Offer>()
               .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTimeOffset.Now));
        }
    }
}
