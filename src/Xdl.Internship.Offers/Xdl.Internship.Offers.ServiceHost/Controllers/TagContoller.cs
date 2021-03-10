using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Xdl.Internship.Offers.Handlers.Tag;
using Xdl.Internship.Offers.SDK.Identity;
using Xdl.Internship.Offers.SDK.TagDTOs;

namespace Xdl.Internship.Offers.ServiceHost.Controllers
{
    [Authorize]
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
        public async Task<IEnumerable<TagDTO>> GeAllTagsStatistics([FromQuery] bool includeInactive = false)
        {
            return await _mediator.Send(new FindAllTagsStatisticsRequest(includeInactive));
        }

        [Authorize(Roles = "Admin,Moderator")]
        [HttpPost]
        public async Task<ActionResult<TagDTO>> CreateTag([FromBody] CreateTagDTO tag)
        {
            var identity = new CreateIdentity()
            {
                FirstName = User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.GivenName).Value,
                LastName = User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.Name).Value,
            };

            return Ok(await _mediator.Send(new InsertTagRequest(tag, identity)));
        }

        [Authorize(Roles = "Admin,Moderator")]
        [HttpDelete]
        [Route("{tagId}")]
        public async Task DeleteTagById([FromRoute] string tagId)
        {
            if (!ObjectId.TryParse(tagId, out var id))
            {
                BadRequest($"{nameof(tagId)} is not valid");
            }

            var identity = new UpdateIdentity()
            {
                FirstName = User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.GivenName).Value,
                LastName = User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.Name).Value,
            };

            await _mediator.Send(new DeleteTagRequest(id, identity));
        }

        [Authorize(Roles = "Admin,Moderator")]
        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<RestoreTagDTO>> RestoreTag([FromRoute] string id, [FromBody] RestoreTagDTO tag)
        {
            if (!ObjectId.TryParse(id, out var parsedId))
            {
                return BadRequest($"{nameof(id)} is not valid");
            }

            var identity = new CreateIdentity()
            {
                FirstName = User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.GivenName).Value,
                LastName = User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.Name).Value,
            };

            return Ok(await _mediator.Send(new RestoreTagRequest(parsedId, tag, identity)));
        }
    }
}
