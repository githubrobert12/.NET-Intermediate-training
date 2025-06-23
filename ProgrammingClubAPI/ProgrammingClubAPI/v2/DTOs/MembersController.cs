using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProgrammingClubAPI.Helpers;
using ProgrammingClubAPI.Models;
using ProgrammingClubAPI.Models.CreateOrUpdateModels;
using ProgrammingClubAPI.Services;
using ProgrammingClubAPI.v1.DTOs;
using ProgrammingClubAPI.v2.DTOs;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProgrammingClubAPI.v2
{
    [Route("api/v4/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IMembersService _membersService;
        private readonly IMapper _mapper;
        public MembersController(IMembersService membersService, IMapper mapper)
        {
            _membersService = membersService;
            _mapper = mapper;
        }

        // GET: api/<MembersController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var members = await _membersService.GetAllMembersAsync();
                if (members.Count() <= 0)
                {
                    //return NotFound("No members found.");
                    return StatusCode((int)HttpStatusCode.OK, ErrorMessagesEnum.NoMembersFound);
                }
                var membersV2s = _mapper.Map<IEnumerable<MemberV2DTO>>(members);
                return Ok(membersV2s);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}