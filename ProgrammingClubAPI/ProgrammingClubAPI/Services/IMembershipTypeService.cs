using ProgrammingClubAPI.Models;

namespace ProgrammingClubAPI.Services
{
    public interface IMembershipTypeService
    {
        Task<IEnumerable<MembershipType>> GetAllMembershipTypesAsync();
        Task<MembershipType> GetMembershipTypeByIdAsync(Guid id);
        Task AddMembershipTypeAsync(MembershipType membershipType);
    }
}
