using MediatR;
using ProgrammingClubAPI.Models;

namespace ProgrammingClubAPI.CQRS.Queries
{
    public class GetAllMembershipsQuery : IRequest<IEnumerable<Membership>>
    {
    }
}
