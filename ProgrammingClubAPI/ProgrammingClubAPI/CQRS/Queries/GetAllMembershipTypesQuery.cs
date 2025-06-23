using MediatR;
using ProgrammingClubAPI.Models;

namespace ProgrammingClubAPI.CQRS.Queries
{
    //Vreau sa obtim toate tipurile de membership din baza de date
    public class GetAllMembershipTypesQuery : IRequest<IEnumerable<MembershipType>>
    {
    }
}
