using MediatR;
using ProgrammingClubAPI.CQRS.Commands;
using ProgrammingClubAPI.DataContext;

namespace ProgrammingClubAPI.CQRS.Handlers
{
    public class CreateMembershipHandler : IRequestHandler<CreateMembershipCommand, Guid>
    {
        private readonly ProgrammingClubDataContext _context;

        public CreateMembershipHandler(ProgrammingClubDataContext context)
        {
            _context = context;
        }


        public async Task<Guid> Handle(CreateMembershipCommand request, CancellationToken cancellationToken)
        {
            var membership = new Models.Membership
            {
                IdMembership = Guid.NewGuid(),
                IdMembershipType = request.Dto.IdMembershipType,
                StartDate = request.Dto.StartDate,
                EndDate = request.Dto.EndDate,
                Level = request.Dto.Level,
            };

            _context.Memberships.Add(membership);
            await _context.SaveChangesAsync(cancellationToken);

            return membership.IdMembership;
        }
    }
}
