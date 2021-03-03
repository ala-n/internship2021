using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
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
        [Route("/topTags")]
        public async Task<IEnumerable<TagMainDTO>> GeTopTags()
        {
            return await _mediator.Send(new FindTopTagsRequest());
        }

        [HttpGet]
        [Route("{tagId}")]
        public async Task<ActionResult<IEnumerable<TagDTO>>> FindTagById([FromRoute] string tagId)
        {
            if (!ObjectId.TryParse(tagId, out var id))
            {
                return BadRequest($"{nameof(tagId)} is not valid");
            }

            return Ok(await _mediator.Send(new FindTagByIdRequest(id)));
        }

        [HttpGet]
        [Route("/allTags")]
        public async Task<IEnumerable<TagMainDTO>> GeAllTags()
        {
            return await _mediator.Send(new FindAllTagsRequest());
        }

        [HttpGet]
        [Route("/allTagsStatistics")]
        public async Task<IEnumerable<TagStatisticsDTO>> GeAllTagsStatistics()
        {
            return await _mediator.Send(new FindAllTagsStatisticsRequest());
        }

        [HttpPost]
        [Route("/tag")]
        public async Task<ActionResult<TagDTO>> CreateVendorEntity([FromBody] CreateTagDTO tag)
        {
            return Ok(await _mediator.Send(new InsertTagRequest(tag)));
        }
    }
}
