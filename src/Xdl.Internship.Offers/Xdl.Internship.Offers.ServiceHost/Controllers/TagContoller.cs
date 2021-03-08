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
        [Route("topTags")]
        public async Task<IEnumerable<TagMainDTO>> GetTopTags()
        {
            return await _mediator.Send(new FindTopTagsRequest(false));
        }

        [HttpGet]
        public async Task<IEnumerable<TagMainDTO>> GeAllTags([FromQuery] bool includeInactive = false)
        {
            return await _mediator.Send(new FindAllTagsRequest(includeInactive));
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
        [Route("statistics")]
        public async Task<IEnumerable<TagStatisticsDTO>> GeAllTagsStatistics([FromQuery] bool includeInactive = false)
        {
            return await _mediator.Send(new FindAllTagsStatisticsRequest(includeInactive));
        }

        [HttpPost]
        public async Task<ActionResult<TagDTO>> CreateTag([FromBody] CreateTagDTO tag)
        {
            return Ok(await _mediator.Send(new InsertTagRequest(tag)));
        }

        [HttpDelete]
        [Route("{tagId}")]
        public async Task DeleteTagById([FromRoute] string tagId)
        {
            if (!ObjectId.TryParse(tagId, out var id))
            {
                BadRequest($"{nameof(tagId)} is not valid");
            }

            await _mediator.Send(new DeleteTagRequest(id));
        }
    }
}
