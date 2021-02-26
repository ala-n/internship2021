using System;
using System.Collections.Generic;
using MediatR;
using Xdl.Internship.Offers.DTOs.TagDTOs;

namespace Xdl.Internship.Offers.Handlers.Tag
{
    public class FindTopTagsRequest : IRequest<ICollection<TagDTO>>
    {
    }
}
