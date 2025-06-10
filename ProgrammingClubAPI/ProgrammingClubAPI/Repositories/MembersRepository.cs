using Microsoft.EntityFrameworkCore;
using ProgrammingClubAPI.Models;

namespace ProgrammingClubAPI.Repositories
{
    public class MembersRepository : IMembersRepository
    {
        private readonly DataContext.ProgrammingClubDataContext _context;

        public MembersRepository(DataContext.ProgrammingClubDataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Member>> GetAllMembersAsync()
        {
            return await _context.Members.ToListAsync();
        }

        public async Task<Member> GetMemberByIdAsync(Guid id)
        {
            return await _context.Members
                .FirstOrDefaultAsync(m => m.IdMember == id);
        }

        public async Task AddMemberAsync(Member member)
        {
            //_context.Members.Add(member);
            _context.Entry(member).State = EntityState.Added;
            await _context.SaveChangesAsync();
            // return member;
        }
        public async Task<bool> UsernameExistsAsync(string username)
        {
            return await _context.Members.AnyAsync(m => m.Username == username);
        }

        public async Task<Member> UpdateMemberAsync(Guid id, Member member)
        {
            if (id != member.IdMember)
            {
                throw new ArgumentException("Member ID mismatch.");
            }

            _context.Update(member);
            await _context.SaveChangesAsync();

            return member;
        }

        public async Task<bool> MemberExistsAsync(Guid id)
        {
            return await _context.Members.AnyAsync(m => m.IdMember == id);
        }

        public async Task<Member> UpdateMemberPartiallyAsync(Guid id, Member member)
        {
            Member memberFromDb = await GetMemberByIdAsync(member.IdMember);

            if (memberFromDb == null)
            {
                return null;
            }

            UpdateIfNullOrEmpty(member.Username, value => memberFromDb.Username = value);
            UpdateIfNullOrEmpty(member.Password, value => memberFromDb.Password = value);
            UpdateIfNullOrEmpty(member.Name, value => memberFromDb.Name = value);
            UpdateIfNullOrEmpty(member.Title, value => memberFromDb.Title = value);
            UpdateIfNullOrEmpty(member.Description, value => memberFromDb.Description = value);
            UpdateIfNullOrEmpty(member.Resume, value => memberFromDb.Resume = value);


            _context.Update(memberFromDb);
            await _context.SaveChangesAsync();
            return memberFromDb;
        }

        public void UpdateIfNullOrEmpty(string newValue, Action<string> setter) {
            if (string.IsNullOrEmpty(newValue))
            {
                setter(newValue);
            }
        }

    }
}
