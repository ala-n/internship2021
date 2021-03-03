using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Xdl.Internship.Offers.Models;
using Xdl.Internship.Offers.SDK.OfferDTOs;

namespace Xdl.Internship.Offers.SDK.OfferDTOs
{
    public class OfferProfile : Profile
    {
        public OfferProfile()
        {
            CreateMap<Offer, OfferDTO>();
            CreateMap<Offer, OfferForListDTO>()
                .ReverseMap();
            CreateMap<Offer, OfferSmallDTO>()
                .ReverseMap();
            CreateMap<Offer, OfferMainDTO>()
                .ReverseMap();
        }
    }
}
