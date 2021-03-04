using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Xdl.Internship.Offers.Models;
using Xdl.Internship.Offers.SDK.FeedbackDTOs;

namespace Xdl.Internship.Offers.SDK.FeedbackDTOs
{
    public class FeedbackProfile : Profile
    {
        public FeedbackProfile()
        {
            CreateMap<Feedback, FeedbackDTO>();

            CreateMap<Feedback, FeedbackMainDTO>();
        }
    }
}
