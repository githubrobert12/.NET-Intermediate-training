using MediatR;
using ProgrammingClubAPI.CQRS.DTOs;

namespace ProgrammingClubAPI.CQRS.Commands
{                                                 // Guid e aici tipul de return al requestului
    public class CreateMembershipTypeCommand : IRequest<Guid>
    {
        public CreateMembershipTypeDTO Dto { get; set; }
        public CreateMembershipTypeCommand(CreateMembershipTypeDTO dto)

        {
            Dto = dto;
        }
    }
}
