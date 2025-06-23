using AutoMapper.Execution;
using Microsoft.EntityFrameworkCore;
using ProgrammingClubAPI.DataContext;
using ProgrammingClubAPI.Models;

namespace ProgrammingClubAPI.Repositories
{
    public class AnnouncementsRepository : IAnnouncementsRepository
    {
        private readonly ProgrammingClubDataContext _context;

        public AnnouncementsRepository(ProgrammingClubDataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Announcement>> GetAllAnnouncementsAsync()
        {
            return await _context.Announcements.ToListAsync();
        }

        public async Task<Announcement> GetAnnouncementByIdAsync(Guid id)
        {
            return await _context.Announcements.FirstOrDefaultAsync(a => a.IdAnnouncement == id);
        }

        public async Task<Announcement> PostAnnouncementAsync(Announcement announcement)
        {
            if (announcement.IdAnnouncement != Guid.Empty)
            {
                _context.Entry(announcement).State = EntityState.Added;
               await _context.SaveChangesAsync();
                return announcement;
            }
            return null;
        }
    }
            
}
