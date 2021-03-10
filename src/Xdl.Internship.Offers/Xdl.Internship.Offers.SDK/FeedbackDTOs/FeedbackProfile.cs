using AutoMapper;
using MongoDB.Bson;
using Xdl.Internship.Offers.Models;

namespace Xdl.Internship.Offers.SDK.FeedbackDTOs
{
    public class FeedbackProfile : Profile
    {
        public FeedbackProfile()
        {
            CreateMap<Feedback, FeedbackDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()))
                .ForMember(dest => dest.OfferId, opt => opt.MapFrom(src => src.OfferId.ToString()))
                .ForMember(dest => dest.Rate, opt => opt.MapFrom(src => src.Rate));

            CreateMap<CreateFeedback, Feedback>()
                .ForMember(dest => dest.OfferId, opt => opt.MapFrom(src => new ObjectId(src.OfferId)))
                .ForMember(dest => dest.VendorId, opt => opt.MapFrom(src => new ObjectId(src.VendorId)))
                .ForMember(dest => dest.Rate, opt => opt.MapFrom(src => src.Rate));
        }
    }
}
