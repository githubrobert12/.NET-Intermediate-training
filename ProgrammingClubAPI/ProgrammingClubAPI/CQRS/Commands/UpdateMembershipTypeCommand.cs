using MediatR;
using ProgrammingClubAPI.CQRS.DTOs;
using ProgrammingClubAPI.Models;

namespace ProgrammingClubAPI.CQRS.Commands
{
    public class UpdateMembershipTypeCommand :IRequest<MembershipType>
    {
        public MembershipType dto { get; set; }

        public UpdateMembershipTypeCommand(MembershipType dto)
        {
            this.dto = dto;
        }
    }
}
