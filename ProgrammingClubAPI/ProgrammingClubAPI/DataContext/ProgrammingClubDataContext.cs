using Microsoft.EntityFrameworkCore;

namespace ProgrammingClubAPI.DataContext
{
    public class ProgrammingClubDataContext : DbContext
    {
        public ProgrammingClubDataContext(DbContextOptions<ProgrammingClubDataContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=ProgrammingClub;Trusted_Connection=True; Encrypt=False").LogTo(Console.WriteLine, LogLevel.Information);
        }

        public DbSet<Models.Member> Members { get; set; }
        public DbSet<Models.Announcement> Announcements { get; set; }
        public DbSet<Models.MembershipType> MembershipTypes { get; set; }
        public DbSet<Models.Membership> Memberships { get; set; }
        public DbSet<Models.CodeSnippet> CodeSnippets { get; set; }


    }
}
