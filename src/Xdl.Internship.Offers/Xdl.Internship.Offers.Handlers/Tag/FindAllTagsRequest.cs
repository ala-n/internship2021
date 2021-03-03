using System;
using System.Collections.Generic;
using MediatR;
using Xdl.Internship.Offers.SDK.TagDTOs;

namespace Xdl.Internship.Offers.Handlers.Tag
{
    public class FindAllTagsRequest : IRequest<ICollection<TagMainDTO>>
    {
        public bool IncludeInactive { get; }

        public FindAllTagsRequest(bool includeInactive)
        {
            IncludeInactive = includeInactive;
        }
    }
}
