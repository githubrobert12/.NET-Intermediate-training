using Microsoft.AspNetCore.Mvc;
using ProgrammingClubAPI.Services;
using ProgrammingClubAPI.Helper;
using ProgrammingClubAPI.Models;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProgrammingClubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembershipTypeController : ControllerBase
    {
        private readonly IMembershipTypeService _membershipTypeService;

        public MembershipTypeController(IMembershipTypeService membershipTypeService)
        {
            _membershipTypeService = membershipTypeService;
        }

        // GET: api/<MembershipTypeController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var membershipTypes = await  _membershipTypeService.GetAllMembershipTypesAsync();
                if (membershipTypes == null || !membershipTypes.Any())
                {
                    return StatusCode((int)HttpStatusCode.OK, ErrorMessagesEnum.NoMembershipTypesFound);
                }
                return Ok(membershipTypes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
           
        }

        // GET api/<MembershipTypeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MembershipTypeController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MembershipType membershipType)
        {
            try { 
                if (membershipType == null)
                {
                    return BadRequest("Membership Type cannot be null.");
                }

                await _membershipTypeService.AddMembershipTypeAsync(membershipType);
                return StatusCode((int)HttpStatusCode.OK, SuccessMessagesEnum.MembershipTypeAdded);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT api/<MembershipTypeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MembershipTypeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
