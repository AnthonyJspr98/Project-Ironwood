using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ironwood.Application.Common.Interfaces;
using Ironwood.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ironwood.Application.Teams.Queries
{
    public class GetAllTeamsQuery : IRequest<IEnumerable<Team>>
    {
        public class GetAllTeamsQueryHandler : IRequestHandler<GetAllTeamsQuery, IEnumerable<Team>>
        {
            private readonly IIronwoodDbContext dbContext;
            private readonly IMediator mediator;
            private readonly ICurrentUser currentUser;

            public GetAllTeamsQueryHandler(IIronwoodDbContext dbContext, IMediator mediator, ICurrentUser current)
            {
                this.dbContext = dbContext;
                this.mediator = mediator;
                this.currentUser = current;
            }
            public async Task<IEnumerable<Team>> Handle(GetAllTeamsQuery request, CancellationToken cancellationToken)
            {
                var _allTeams = await  dbContext.Teams.ToListAsync();

                return _allTeams;
            }
        }
    }
}