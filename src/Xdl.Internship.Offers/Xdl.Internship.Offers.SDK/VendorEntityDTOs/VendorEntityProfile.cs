using System;
using AutoMapper;
using MongoDB.Bson;
using Xdl.Internship.Offers.Models;

namespace Xdl.Internship.Offers.SDK.VendorEntityDTOs
{
    public class VendorEntityProfile : Profile
    {
        public VendorEntityProfile()
        {
            CreateMap<VendorEntity, VendorEntityDTO>();

            CreateMap<VendorEntity, VendorEntityWithVendorNameDTO>();

            CreateMap<Vendor, VendorEntityWithVendorNameDTO>()
                .ForMember(dest => dest.VendorName, opt => opt.MapFrom(src => src.Name))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<CreateVendorEntityDTO, VendorEntity>()
                .ForPath(dest => dest.Address.Country, opt => opt.MapFrom(src => src.Country))
                .ForPath(dest => dest.Address.CityId, opt => opt.MapFrom(src => ObjectId.Parse(src.CityId)))
                .ForPath(dest => dest.Address.Street, opt => opt.MapFrom(src => src.Street))
                .ForPath(dest => dest.Address.House, opt => opt.MapFrom(src => src.House))
                .ForPath(dest => dest.Address.Room, opt => opt.MapFrom(src => src.Room))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTimeOffset.Now))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTimeOffset.Now));

            CreateMap<UpdateVendorEntityDTO, VendorEntity>()
                .ForPath(dest => dest.Address.Country, opt => opt.MapFrom(src => src.Country))
                .ForPath(dest => dest.Address.CityId, opt => opt.MapFrom(src => ObjectId.Parse(src.CityId)))
                .ForPath(dest => dest.Address.Street, opt => opt.MapFrom(src => src.Street))
                .ForPath(dest => dest.Address.House, opt => opt.MapFrom(src => src.House))
                .ForPath(dest => dest.Address.Room, opt => opt.MapFrom(src => src.Room))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTimeOffset.Now));

            CreateMap<VendorEntityMainDTO, VendorEntity>()
                .ForPath(dest => dest.Address.Country, opt => opt.MapFrom(src => src.Address.Country))
                .ForPath(dest => dest.Address.CityId, opt => opt.MapFrom(src => src.Address.CityId))
                .ForPath(dest => dest.Address.Street, opt => opt.MapFrom(src => src.Address.Street))
                .ForPath(dest => dest.Address.House, opt => opt.MapFrom(src => src.Address.House))
                .ForPath(dest => dest.Address.Room, opt => opt.MapFrom(src => src.Address.Room))
               .ReverseMap();
        }
    }
}
