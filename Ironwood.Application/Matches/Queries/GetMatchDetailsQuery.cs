using System;
using System.Threading;
using System.Threading.Tasks;
using Ironwood.Application.Common.Interfaces;
using Ironwood.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ironwood.Application.Matches.Queries
{
    public class GetMatchDetailsQuery : IRequest<Match>
    {
        public Guid UID { get; set; }
        public class GetMatchDetailsQueryHandler : IRequestHandler<GetMatchDetailsQuery, Match>
        {
            private readonly IIronwoodDbContext dbContext;
            public GetMatchDetailsQueryHandler(IIronwoodDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<Match> Handle(GetMatchDetailsQuery request, CancellationToken cancellationToken)
            {
                Match _matchDetail = await dbContext.Matches
                .SingleOrDefaultAsync(a => a.UID == request.UID);

                if (_matchDetail != null)
                {
                    return _matchDetail;
                }              
                    throw new Exception("Does not exist");               
            }
        }
    }
}