using System;
using AutoMapper;
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
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTimeOffset.Now));

            CreateMap<UpdateOfferDTO, Offer>()
               .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTimeOffset.Now));
        }
    }
}
