using ProgrammingClubAPI.Models;

namespace ProgrammingClubAPI.Repositories
{
    public interface IMembersRepository
    {
        Task<IEnumerable<Member>> GetAllMembersAsync();
        Task<Member> GetMemberByIdAsync(Guid id);
     //   Task<Member> GetMemberByUsername(Guid id);

        Task AddMemberAsync(Member member);
        Task<Member> UpdateMemberAsync(Guid id, Member member);
        Task<Member> UpdateMemberPartiallyAsync(Guid id, Member member);
        //    Task DeleteMemberAsync(Guid id);
        Task<bool> MemberExistsAsync(Guid id);
        Task<bool> UsernameExistsAsync(string username);

      
    }
}
