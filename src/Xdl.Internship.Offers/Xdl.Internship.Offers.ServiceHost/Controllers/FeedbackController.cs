using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Xdl.Internship.Offers.Handlers.Feedback;
using Xdl.Internship.Offers.Handlers.Offer;
using Xdl.Internship.Offers.SDK.FeedbackDTOs;
using Xdl.Internship.Offers.SDK.OfferDTOs;

namespace Xdl.Internship.Offers.ServiceHost.Controllers
{
    [Authorize]
    [Route("api/feedback")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FeedbackController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("add")]
        public async Task<ActionResult<FeedbackDTO>> AddFeedback([FromBody] CreateFeedback feedback)
        {
            try
            {
                return Ok(await _mediator.Send(new AddFeedbackRequest(feedback,
                        User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value)));
            }
            catch (Exception ex)
            {
                if (ex is NullReferenceException)
                {
                    return BadRequest("Please enter all necessary field");
                }
                else if (ex is ArgumentOutOfRangeException ||
                         ex is IndexOutOfRangeException ||
                         ex is FormatException ||
                         ex is AutoMapperMappingException)
                {
                    return BadRequest("Please enter valid value");
                }

                throw;
            }
        }

        [HttpGet("{offerId}")]
        public async Task<ActionResult<FeedbackDTO>> GetFeedback([FromRoute] string offerId)
        {
            try
            {
                return Ok(await _mediator.Send(new GetFeedbackRequest(offerId,
                          User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value)));
            }
            catch (Exception ex)
            {
                if (ex is NullReferenceException ||
                    ex is AutoMapperMappingException ||
                    ex is FormatException)
                {
                    return BadRequest("Something went wrong");
                }

                throw;
            }
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<OfferWithAllInfoDTO>>> GetAllFeedbacks()
        {
            try
            {
                List<OfferWithAllInfoDTO> result = new List<OfferWithAllInfoDTO>();
                ICollection<FeedbackDTO> feedbacks = await _mediator.Send(new GetAllFeedbacksRequest(
                    User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value));
                foreach (var feedback in feedbacks)
                {
                    OfferWithAllInfoDTO offer = await _mediator.Send(new FindOfferByIdWithVendorInfoRequest(new ObjectId(feedback.OfferId)));
                    if (offer != null)
                    {
                        result.Add(offer);
                    }
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                if (ex is NullReferenceException ||
                    ex is AutoMapperMappingException ||
                    ex is FormatException)
                {
                    return BadRequest("Something went wrong");
                }

                throw;
            }
        }

        [HttpPut("{offerId}/{rate}")]
        public async Task<ActionResult<FeedbackDTO>> UpdateFeedback([FromRoute] string offerId, [FromRoute] int rate)
        {
            try
            {
                return Ok(await _mediator.Send(new UpdateFeedbackRequest(
                          offerId,
                          rate,
                          User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value)));
            }
            catch (Exception ex)
            {
                if (ex is NullReferenceException)
                {
                    return BadRequest("Please enter all necessary field");
                }
                else if (ex is ArgumentOutOfRangeException ||
                         ex is IndexOutOfRangeException ||
                         ex is FormatException ||
                         ex is AutoMapperMappingException)
                {
                    return BadRequest("Please enter valid value");
                }

                throw;
            }
        }
    }
}
