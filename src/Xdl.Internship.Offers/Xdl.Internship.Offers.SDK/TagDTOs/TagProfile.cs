using System;
using AutoMapper;
using Xdl.Internship.Offers.Models;
using Xdl.Internship.Offers.SDK.Identity;
using Xdl.Internship.Offers.SDK.TagDTOs;

namespace Xdl.Internship.Offers.SDK.TagDTOs
{
    public class TagProfile : Profile
    {
        public TagProfile()
        {
            CreateMap<Tag, TagDTO>();

            CreateMap<Tag, TagMainDTO>();

            CreateMap<CreateTagDTO, Tag>()
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.UsesByUser, opt => opt.MapFrom(s => 0))
                .ForMember(d => d.UsesByVendor, opt => opt.MapFrom(s => 0))
                .ForMember(d => d.CreatedAt, opt => opt.MapFrom(s => DateTimeOffset.Now))
                .ForMember(d => d.UpdatedAt, opt => opt.MapFrom(s => DateTimeOffset.Now));

            CreateMap<CreateIdentity, Tag>()
                .ForMember(d => d.CreatedBy, opt => opt.MapFrom(s => s.GetValue()))
                .ForMember(d => d.UpdatedBy, opt => opt.MapFrom(s => s.GetValue()));

            CreateMap<UpdateIdentity, Tag>()
                .ForMember(d => d.UpdatedBy, opt => opt.MapFrom(s => s.GetValue()));

            CreateMap<RestoreTagDTO, Tag>();
        }
    }
}