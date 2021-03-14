using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ironwood.Application.Common.Interfaces;
using Ironwood.Domain.Entities;
using Ironwood.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ironwood.Application.Matches.Queries
{
    public class GetAllIncomingDotaMatchQuery : IRequest<IEnumerable<Match>>
    {
        public class GetAllIncomingDotaMatchQueryHandler : IRequestHandler<GetAllIncomingDotaMatchQuery, IEnumerable<Match>>
        {
            private readonly IIronwoodDbContext dbContext;
            public GetAllIncomingDotaMatchQueryHandler(IIronwoodDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<IEnumerable<Match>> Handle(GetAllIncomingDotaMatchQuery request, CancellationToken cancellationToken)
            {
                var _allIncomingDotaMatch = await dbContext.Matches
                .Where(a => a.Status == MatchStatus.Incoming && a.MatchCategory == MatchCategory.Dota2)
                .Include(a => a.MatchTeamDetails)
                .ThenInclude(a => a.Team)              
                .Include(a => a.Tournament)               
                .ToListAsync();

                return _allIncomingDotaMatch;
            }
        }
    }
}