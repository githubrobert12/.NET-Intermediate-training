using ProgrammingClubAPI.Models;
using ProgrammingClubAPI.Repositories;

namespace ProgrammingClubAPI.Services
{
    public class MembershipTypeService : IMembershipTypeService
    {
        private readonly IMembershipTypeRepository _membershipTypeRepository;

        public MembershipTypeService(IMembershipTypeRepository membershipTypeRepository)
        {
            _membershipTypeRepository = membershipTypeRepository;
        }

        public async Task<IEnumerable<MembershipType>> GetAllMembershipTypesAsync()
        {
            return await _membershipTypeRepository.GetAllMembershipTypesAsync();
        }

        public async Task<MembershipType> GetMembershipTypeByIdAsync(Guid id)
        {
            return await _membershipTypeRepository.GetMembershipTypeByIdAsync(id);
        }

        public async Task AddMembershipTypeAsync(MembershipType membershipType)
        {
            if(await _membershipTypeRepository.MembershipTypeExistsAsync(membershipType.Name))
            {
                throw new ArgumentException("Membership Type already exists.", nameof(membershipType.Name));
            }

            membershipType.IdMembershipType = Guid.NewGuid(); // Ensure a new ID is generated for the membership type
            await _membershipTypeRepository.AddMembershipTypeAsync(membershipType);
        }

    }
}
