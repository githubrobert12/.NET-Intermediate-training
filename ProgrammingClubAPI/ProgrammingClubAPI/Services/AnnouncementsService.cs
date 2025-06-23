using ProgrammingClubAPI.Models;
using ProgrammingClubAPI.Repositories;

namespace ProgrammingClubAPI.Services
{
    public class AnnouncementsService : IAnnouncementsService
    {
        private readonly IAnnouncementsRepository _announcementsRepository;

        public AnnouncementsService(IAnnouncementsRepository announcementsRepository)
        {
            _announcementsRepository = announcementsRepository;
        }

        public async Task <IEnumerable<Announcement>> GetAllAnnouncementsAsync()
        {
            return await _announcementsRepository.GetAllAnnouncementsAsync();
        }

        public async Task<Announcement> GetAnnouncementByIdAsync(Guid id)
        {
            return await _announcementsRepository.GetAnnouncementByIdAsync(id);
        }

        public async Task<Announcement> PostAnnouncementAsync(Announcement announcement)
        {
            if (announcement.IdAnnouncement == Guid.Empty)
            {
                announcement.IdAnnouncement = Guid.NewGuid();
            }
            return await _announcementsRepository.PostAnnouncementAsync(announcement);
        }
    }
}
