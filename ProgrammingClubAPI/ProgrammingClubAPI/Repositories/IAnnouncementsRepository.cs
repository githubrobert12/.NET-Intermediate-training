using ProgrammingClubAPI.Models;

namespace ProgrammingClubAPI.Repositories
{
    public interface IAnnouncementsRepository
    {
        Task<IEnumerable<Announcement>> GetAllAnnouncementsAsync();
        Task<Announcement> GetAnnouncementByIdAsync(Guid id);
        Task<Announcement> PostAnnouncementAsync(Announcement announcement);

    }
}
