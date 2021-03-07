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

            CreateMap<Offer, OfferWithAllInfoDTO>()
                .ReverseMap();

            CreateMap<Vendor, OfferWithAllInfoDTO>()
                .ForMember(dest => dest.VendorId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.VendorName, opt => opt.MapFrom(src => src.Name))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<Offer, OfferWithVendorNameDTO>()
               .ReverseMap();

            CreateMap<Vendor, OfferWithVendorNameDTO>()
                .ForMember(dest => dest.VendorId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.VendorName, opt => opt.MapFrom(src => src.Name))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<CreateOfferDTO, Offer>()
                .ForMember(dest => dest.Rate, opt => opt.MapFrom(src => 0))
                .ForMember(dest => dest.NumberOfUses, opt => opt.MapFrom(src => 0))
                .ForMember(dest => dest.NumberOfViews, opt => opt.MapFrom(src => 0))
                .ForMember(dest => dest.VendorEntitiesId, opt => opt.MapFrom(src => src.VendorEntitiesId.Select(el => ObjectId.Parse(el))))
                .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.Tags.Select(el => ObjectId.Parse(el))))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTimeOffset.Now));

            CreateMap<UpdateOfferDTO, Offer>()
               .ForMember(dest => dest.VendorEntitiesId, opt => opt.MapFrom(src => src.VendorEntitiesId.Select(el => ObjectId.Parse(el))))
               .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.Tags.Select(el => ObjectId.Parse(el))))
               .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTimeOffset.Now));
        }
    }
}
