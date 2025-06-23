using MediatR;
using ProgrammingClubAPI.CQRS.DTOs;

namespace ProgrammingClubAPI.CQRS.Commands
{
    public class CreateMembershipCommand : IRequest<Guid>
    {
        public MembershipDTO Dto { get; set; }

        public CreateMembershipCommand(MembershipDTO dto)
        {
            Dto = dto;
        }
    }
}
