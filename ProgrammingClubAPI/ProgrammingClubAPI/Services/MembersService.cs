using ProgrammingClubAPI.DataContext;
using ProgrammingClubAPI.Models;
using ProgrammingClubAPI.Models.NewFolder;
using ProgrammingClubAPI.Repositories;

namespace ProgrammingClubAPI.Services
{
    public class MembersService : IMembersService
    {

        private readonly IMembersRepository _membersRepository;

        public MembersService(IMembersRepository membersRepository)
        {
            _membersRepository = membersRepository;
        }


        public async Task<IEnumerable<Member>> GetAllMembersAsync()
        {
            return await _membersRepository.GetAllMembersAsync();
        }

        public async Task<Member> GetMemberByIdAsync(Guid id)
        {
            return await _membersRepository.GetMemberByIdAsync(id);
        }
        public async Task AddMemberAsync(Member member)
        {
            if (await _membersRepository.UsernameExistsAsync(member.Username))
            {
                throw new ArgumentException("Username already exists.", nameof(member.Username));
            }

            member.IdMember = Guid.NewGuid(); // Ensure a new ID is generated for the member
            await _membersRepository.AddMemberAsync(member);
        }

        public async Task<Member> UpdateMemberAsync(Guid id, Member member)
        {
            if (!await _membersRepository.MemberExistsAsync(id))
            {
                return null;
            }

            member.IdMember = id; // Ensure the ID is set to the existing member's ID

            return await _membersRepository.UpdateMemberAsync(id, member);
        }

        public async Task<Member> UpdateMemberPartiallyAsync(Guid id, UpdateMemberPartially updateMember)
        {
            if (!await _membersRepository.MemberExistsAsync(id))
            {
                return null;
            }

            Member member = new Member
            {
                IdMember = id,
                Username = updateMember.Username,
                Password = updateMember.Password,
                Name = updateMember.Name,
                Title = updateMember.Title,
                Description = updateMember.Description,
                Resume = updateMember.Resume

            };

            return member;

        }
      
    }
  
    
}
