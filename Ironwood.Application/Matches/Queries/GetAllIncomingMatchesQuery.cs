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
    public class GetAllIncomingMatchesQuery : IRequest<IEnumerable<Match>>
    {
        public class GetAllIncomingMatchesQueryHandler : IRequestHandler<GetAllIncomingMatchesQuery, IEnumerable<Match>>
        {
            private readonly IIronwoodDbContext dbContext;
            public GetAllIncomingMatchesQueryHandler(IIronwoodDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<IEnumerable<Match>> Handle(GetAllIncomingMatchesQuery request, CancellationToken cancellationToken)
            {
                var _allIncoming = await dbContext.Matches
                .Where(a => a.Status == MatchStatus.Incoming)
                .Include(a => a.MatchTeamDetails)
                .ThenInclude(a => a.Team)
                .Include(a => a.Category)
                .Include(a => a.Tournament)               
                .ToListAsync();

                return _allIncoming;
            }
        }
    }
}