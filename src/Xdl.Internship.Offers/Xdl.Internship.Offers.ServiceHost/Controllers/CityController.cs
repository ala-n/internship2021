using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Xdl.Internship.Offers.Handlers.City;
using Xdl.Internship.Offers.SDK.CityDTOs;

namespace Xdl.Internship.Offers.ServiceHost.Controllers
{
    [Controller]
    [Route("api/cities/")]
    public class CityController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<CityDTO>>> GetAllCities([FromQuery]bool includeInactive = false)
        {
            return Ok(await _mediator.Send(new FindCitiesRequest(includeInactive)));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<CityDTO>> GetCityById([FromRoute] string id)
        {
            if (ObjectId.TryParse(id, out var parseId))
            {
                return BadRequest($"{nameof(id)} is not valid");
            }

            return Ok(await _mediator.Send(new FindCityByIdRequest(parseId)));
        }

        // [HttpPost]
        // [Route("{id}")]
        // public async Task<IActionResult<CityDTO>>
    }
}
