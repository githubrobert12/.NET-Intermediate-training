using MediatR;
using Microsoft.EntityFrameworkCore;
using ProgrammingClubAPI.CQRS.Queries;
using ProgrammingClubAPI.DataContext;
using ProgrammingClubAPI.Models;

namespace ProgrammingClubAPI.CQRS.Handlers
{
    public class GetAllMembershipsHandler : IRequestHandler<GetAllMembershipsQuery, IEnumerable<Membership>>
    {
        private readonly ProgrammingClubDataContext _context;

        public GetAllMembershipsHandler(ProgrammingClubDataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Membership>> Handle(GetAllMembershipsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Memberships.ToListAsync(cancellationToken);
        }
    }
}
