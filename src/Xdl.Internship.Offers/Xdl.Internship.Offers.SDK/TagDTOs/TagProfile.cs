using AutoMapper;
using Xdl.Internship.Offers.Models;
using Xdl.Internship.Offers.SDK.TagDTOs;

namespace Xdl.Internship.Offers.SDK.TagDTOs
{
    public class TagProfile : Profile
    {
        public TagProfile()
        {
            CreateMap<Tag, TagDTO>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.CreatedBy, opt => opt.MapFrom(s => s.CreatedBy))
                .ForMember(d => d.CreatedAt, opt => opt.MapFrom(s => s.CreatedAt))
                .ForMember(d => d.UpdatedAt, opt => opt.MapFrom(s => s.UpdatedAt))
                .ForMember(d => d.UpdatedAt, opt => opt.MapFrom(s => s.UpdatedAt))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.UsesByUser, opt => opt.MapFrom(s => s.UsesByUser))
                .ForMember(d => d.UsesByVendor, opt => opt.MapFrom(s => s.UsesByVendor))
                .ForMember(d => d.IsDeleted, opt => opt.MapFrom(s => s.IsDeleted));

            CreateMap<Tag, TagMainDTO>();

            CreateMap<Tag, CreateTagDTO>()
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name));

            CreateMap<Tag, TagStatisticsDTO>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.UsesByUser, opt => opt.MapFrom(s => s.UsesByUser))
                .ForMember(d => d.UsesByVendor, opt => opt.MapFrom(s => s.UsesByVendor))
                .ForMember(d => d.IsDeleted, opt => opt.MapFrom(s => s.IsDeleted));
        }
    }
}