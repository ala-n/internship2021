using System;
using MediatR;
using Xdl.Internship.Offers.SDK.Identity;
using Xdl.Internship.Offers.SDK.TagDTOs;

namespace Xdl.Internship.Offers.Handlers.Tag
{
    public class InsertTagRequest : IRequest<TagDTO>
    {
        public CreateTagDTO TagDTO { get; }

        public CreateIdentity Identity;

        public InsertTagRequest(CreateTagDTO tagDTO, CreateIdentity identity)
        {
            TagDTO = tagDTO;
            Identity = identity;
        }
    }
}