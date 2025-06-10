using Microsoft.EntityFrameworkCore;
using ProgrammingClubAPI.DataContext;
using ProgrammingClubAPI.Models;

namespace ProgrammingClubAPI.Repositories
{
    public class MembershipTypeRepository : IMembershipTypeRepository
    {
        private readonly ProgrammingClubDataContext _context;

        public MembershipTypeRepository(ProgrammingClubDataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MembershipType>> GetAllMembershipTypesAsync()
        {
            return await _context.MembershipTypes.ToListAsync();
        }

        public async Task<MembershipType> GetMembershipTypeByIdAsync(Guid id)
        {
            return await _context.MembershipTypes
                .FirstOrDefaultAsync(mt => mt.IdMembershipType == id);
        }

        public async Task AddMembershipTypeAsync(MembershipType membershipType)
        {
            if (membershipType == null)
            {
                throw new ArgumentNullException(nameof(membershipType));
            }

            _context.MembershipTypes.Add(membershipType);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> MembershipTypeExistsAsync(string name)
        {
            return await _context.MembershipTypes.AnyAsync(mt => mt.Name == name);
        }
    }
}
