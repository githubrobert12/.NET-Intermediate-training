using ProgrammingClubAPI.Models;
using ProgrammingClubAPI.Models.NewFolder;

namespace ProgrammingClubAPI.Services
{
    public interface IMembersService
    {
        Task<IEnumerable<Member>> GetAllMembersAsync();
        Task<Member> GetMemberByIdAsync(Guid id);
        Task AddMemberAsync(Member member);
        Task<Member> UpdateMemberAsync(Guid id, Member member);
        Task<Member> UpdateMemberPartiallyAsync(Guid id, UpdateMemberPartially member);
    }
}
