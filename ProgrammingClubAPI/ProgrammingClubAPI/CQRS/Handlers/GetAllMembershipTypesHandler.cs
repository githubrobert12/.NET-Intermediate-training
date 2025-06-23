using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using ProgrammingClubAPI.CQRS.Queries;
using ProgrammingClubAPI.DataContext;
using ProgrammingClubAPI.Models;

namespace ProgrammingClubAPI.CQRS.Handlers
{   
    // in controller chemam query ul, vine MediatR si cauta handler ul care implementeaza query ul, si se apeleaza metoda Handle
    public class GetAllMembershipTypesHandler : IRequestHandler<GetAllMembershipTypesQuery, IEnumerable<MembershipType>>
    {
        private readonly ProgrammingClubDataContext _context;
        private readonly IMemoryCache _cache;
        public GetAllMembershipTypesHandler(ProgrammingClubDataContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        public async Task<IEnumerable<MembershipType>> Handle(GetAllMembershipTypesQuery request, CancellationToken cancellationToken)
        {
            const string cacheKey = "AllMembershipTypes";

            // 1.Check if the data is already cached
            if (_cache.TryGetValue(cacheKey, out IEnumerable<MembershipType> cachedMembershipTypes))
            {
                return cachedMembershipTypes;
            }
            // 2.If not cached, fetch from the database
            var membershipTypes =  await _context.MembershipTypes.ToListAsync(cancellationToken);

            // 3.Configuram optinile de cache
            var cacheOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(60));

            //4. Salvam datele in cache
            _cache.Set(cacheKey, membershipTypes, cacheOptions);

            return membershipTypes;
        }
    }
}
