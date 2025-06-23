using ProgrammingClubAPI.Models;

namespace ProgrammingClubAPI.Services
{
    public interface IAnnouncementsService
    {
        Task<IEnumerable<Announcement>> GetAllAnnouncementsAsync();
        Task<Announcement> GetAnnouncementByIdAsync(Guid id);
        Task<Announcement> PostAnnouncementAsync(Announcement announcement);
    }
}
