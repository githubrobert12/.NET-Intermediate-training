using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgrammingClubAPI.CQRS.Commands;
using ProgrammingClubAPI.CQRS.DTOs;
using ProgrammingClubAPI.CQRS.Queries;

namespace ProgrammingClubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembershipController : ControllerBase
    {
        private readonly  IMediator _mediator;

        public MembershipController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<MembershipController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {   var query = new GetAllMembershipsQuery();
                var memberships = await _mediator.Send(query);
                if (memberships == null || !memberships.Any())
                {
                    return StatusCode(StatusCodes.Status200OK, "No memberships found.");
                }
                return Ok(memberships);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Post([FromBody] MembershipDTO membership)
        {
            if (membership == null)
            {
                return BadRequest("Membership data is null.");
            }

            try
            {
                var command = new CreateMembershipCommand(membership);
                var result = await _mediator.Send(command);
                return Ok(result);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }
    }
}
