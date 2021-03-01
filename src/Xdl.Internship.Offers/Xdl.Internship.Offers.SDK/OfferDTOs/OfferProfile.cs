using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Xdl.Internship.Offers.Models;
using Xdl.Internship.Offers.SDK.OffersDTOs;

namespace Xdl.Internship.Offers.SDK.OfferDTOs
{
    public class OfferProfile : Profile
    {
        public OfferProfile()
        {
            CreateMap<Offer, OfferDTO>();
            CreateMap<Offer, OfferForListDTO>();
            CreateMap<Offer, OfferSmallDTO>();
            CreateMap<Offer, OfferMainDTO>();
        }
    }
}
