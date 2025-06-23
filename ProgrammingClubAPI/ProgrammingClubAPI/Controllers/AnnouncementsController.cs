using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgrammingClubAPI.Helpers;
using ProgrammingClubAPI.Models;
using ProgrammingClubAPI.Services;
using System.Net;

namespace ProgrammingClubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnouncementsController : ControllerBase
    {
        private readonly IAnnouncementsService _announcementsService;

        public AnnouncementsController(IAnnouncementsService announcementsService)
        {
            _announcementsService = announcementsService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var announcements = await _announcementsService.GetAllAnnouncementsAsync();
                if (announcements == null || !announcements.Any())
                {
                    return StatusCode((int)HttpStatusCode.OK, ErrorMessagesEnum.NoAnnouncementsFound);
                }
                return Ok(announcements);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var announcement = await _announcementsService.GetAnnouncementByIdAsync(id);
                if (announcement == null)
                {
                    return StatusCode((int)HttpStatusCode.OK, ErrorMessagesEnum.AnnouncementNotFound);
                }
                return Ok(announcement);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Announcement announcement)
        {
            if (announcement == null)
            {
                return BadRequest("Announcement data is null.");
            }

            try
            {
                var createdAnnouncement = await _announcementsService.PostAnnouncementAsync(announcement);
                return StatusCode((int)HttpStatusCode.Created, SuccessMessagesEnum.AnnouncementAdded);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }
    }
}
