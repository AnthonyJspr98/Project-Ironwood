using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ironwood.Application.Common.Interfaces;
using Ironwood.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ironwood.Application.Tournaments.Queries
{
    public class GetAllTournamentsQuery : IRequest<IEnumerable<Tournament>>
    {
        public class GetAllTournamentsQueryHandler : IRequestHandler<GetAllTournamentsQuery, IEnumerable<Tournament>>
        {
            private readonly IIronwoodDbContext dbContext;
            private readonly IMediator mediator;
            private readonly ICurrentUser current;
            public GetAllTournamentsQueryHandler(IIronwoodDbContext dbContext, IMediator mediator, ICurrentUser current)
            {
                this.dbContext = dbContext;
                this.mediator = mediator;
                this.current = current;
            }
            public async Task<IEnumerable<Tournament>> Handle(GetAllTournamentsQuery request, CancellationToken cancellationToken)
            {
                var _allTournaments = await dbContext.Tournaments.ToListAsync();
                
                return _allTournaments;
            }
        }
    }
}