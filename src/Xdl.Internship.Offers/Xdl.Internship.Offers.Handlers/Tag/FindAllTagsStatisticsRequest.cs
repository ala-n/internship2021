﻿using System;
using System.Collections.Generic;
using MediatR;
using Xdl.Internship.Offers.SDK.TagDTOs;

namespace Xdl.Internship.Offers.Handlers.Tag
{
    public class FindAllTagsStatisticsRequest : IRequest<ICollection<TagDTO>>
    {
    }
}
