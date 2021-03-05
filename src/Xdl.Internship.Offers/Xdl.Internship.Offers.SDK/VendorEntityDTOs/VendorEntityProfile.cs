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

            CreateMap<CreateVendorEntityDTO, VendorEntity>()
                .ForPath(dest => dest.Address.Country, opt => opt.MapFrom(src => src.Country))
                .ForPath(dest => dest.Address.CityId, opt => opt.MapFrom(src => ObjectId.Parse(src.CityId)))
                .ForPath(dest => dest.Address.Street, opt => opt.MapFrom(src => src.Street))
                .ForPath(dest => dest.Address.House, opt => opt.MapFrom(src => src.House))
                .ForPath(dest => dest.Address.Room, opt => opt.MapFrom(src => src.Room))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTimeOffset.Now));

            CreateMap<UpdateVendorEntityDTO, VendorEntity>()
                .ForPath(dest => dest.Address.Country, opt => opt.MapFrom(src => src.Country))
                .ForPath(dest => dest.Address.CityId, opt => opt.MapFrom(src => ObjectId.Parse(src.CityId)))
                .ForPath(dest => dest.Address.Street, opt => opt.MapFrom(src => src.Street))
                .ForPath(dest => dest.Address.House, opt => opt.MapFrom(src => src.House))
                .ForPath(dest => dest.Address.Room, opt => opt.MapFrom(src => src.Room))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTimeOffset.Now));
        }
    }
}
