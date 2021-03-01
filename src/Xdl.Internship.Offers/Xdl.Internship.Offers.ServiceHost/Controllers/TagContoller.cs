using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Xdl.Internship.Offers.Handlers.Tag;
using Xdl.Internship.Offers.SDK.TagDTOs;

namespace Xdl.Internship.Offers.ServiceHost.Controllers
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
        public async Task<IEnumerable<TagDTO>> GeTopTags()
        {
            return await _mediator.Send(new FindTopTagsRequest());
        }
    }
}
