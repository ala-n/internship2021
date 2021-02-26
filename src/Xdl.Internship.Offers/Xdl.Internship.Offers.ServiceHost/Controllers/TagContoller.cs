﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Xdl.Internship.Offers.DTOs.TagDTOs;
using Xdl.Internship.Offers.Handlers.Tag;

namespace Xdl.Internship.Offers.ServiceHost.Controllers
{
    public class TagContoller : ControllerBase
    {
        [Controller]
        [Route("api/tags")]
        public class TagController : ControllerBase
        {
            private readonly IMediator _mediator;

            public TagController(IMediator mediator)
            {
                _mediator = mediator;
            }

            [HttpGet]
            public async Task<IEnumerable<TagDTO>> GetAll()
            {
                return await _mediator.Send(new FindTopTagsRequest());
            }
        }
    }
}
