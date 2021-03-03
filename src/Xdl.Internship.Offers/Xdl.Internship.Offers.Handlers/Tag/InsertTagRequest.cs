using System;
using MediatR;
using Xdl.Internship.Offers.SDK.TagDTOs;

namespace Xdl.Internship.Offers.Handlers.Tag
{
    public class InsertTagRequest : IRequest<TagDTO>
    {
        public CreateTagDTO TagDTO { get; }

        public InsertTagRequest(CreateTagDTO tagDTO)
        {
            TagDTO = tagDTO;
        }
    }
}