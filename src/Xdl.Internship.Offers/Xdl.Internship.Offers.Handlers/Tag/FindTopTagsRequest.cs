using System;
using System.Collections.Generic;
using MediatR;
using Xdl.Internship.Offers.SDK.TagDTOs;

namespace Xdl.Internship.Offers.Handlers.Tag
{
    public class FindTopTagsRequest : IRequest<ICollection<TagMainDTO>>
    {
        public bool IncludeInactive { get; }

        public FindTopTagsRequest(bool includeInactive)
        {
            IncludeInactive = includeInactive;
        }
    }
}
