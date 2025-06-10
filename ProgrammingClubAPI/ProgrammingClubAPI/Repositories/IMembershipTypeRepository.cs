using ProgrammingClubAPI.Models;

namespace ProgrammingClubAPI.Repositories
{
    public interface IMembershipTypeRepository
    {
        Task <IEnumerable<MembershipType>> GetAllMembershipTypesAsync();
        Task<MembershipType> GetMembershipTypeByIdAsync(Guid id);
        Task AddMembershipTypeAsync(MembershipType membershipType);
        Task<bool> MembershipTypeExistsAsync(string name);
    }
}
