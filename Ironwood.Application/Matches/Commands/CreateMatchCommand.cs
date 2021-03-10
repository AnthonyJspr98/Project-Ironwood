using System;
using System.Threading;
using System.Threading.Tasks;
using Ironwood.Application.Common.Interfaces;
using Ironwood.Domain.Entities;
using Ironwood.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ironwood.Application.Matches.Commands
{
    public class CreateMatchCommand : IRequest<Match>
    {
        //
        public Guid TeamOneUID { get; set; }
        public Guid TeamTwoUID { get; set; }
        public MatchCategory MatchCategory { get; set; }
        public Guid Tournament { get; set; }
        public DateTime MatchDateAndTime { get; set; }
        //
        public class CreateMatchCommandHandler : IRequestHandler<CreateMatchCommand, Match>
        {
            private readonly IIronwoodDbContext dbContext;
            private readonly IMediator mediator;
            private readonly ICurrentUser currentUser;

            public CreateMatchCommandHandler(IIronwoodDbContext dbContext, IMediator mediator, ICurrentUser currentUser)
            {
                this.dbContext = dbContext;
                this.mediator = mediator;
                this.currentUser = currentUser;
            }
            public async  Task<Match> Handle(CreateMatchCommand request, CancellationToken cancellationToken)
            {
                var _teamOne = await dbContext.Teams.SingleOrDefaultAsync(a => a.UID == request.TeamOneUID);
                var _teamTwo = await dbContext.Teams.SingleOrDefaultAsync(a => a.UID == request.TeamTwoUID);
               
                var _tournament = await dbContext.Tournaments.SingleOrDefaultAsync(a => a.UID == request.Tournament);
              
                
                Match _match = new Match
                {
                    UID = Guid.NewGuid(),
                    Status = MatchStatus.Incoming,
                    Tournament = _tournament,
                    MatchDateandTime = request.MatchDateAndTime,    
                    MatchCategory = request.MatchCategory  

                };

                dbContext.Matches.Add(_match);
                
                var _teamOneTeamDetails = new MatchTeamDetail
                {
                    UID = Guid.NewGuid(),
                    Match = _match,
                    Team = _teamOne,
                    IsWon = false
                };
                 _teamOne.MatchTeamDetails.Add(_teamOneTeamDetails);
            
                var _teamTwoTeamDetails = new MatchTeamDetail
                {
                    UID = Guid.NewGuid(),
                    Match = _match,
                    Team = _teamTwo,
                    IsWon = false
                };
                _teamTwo.MatchTeamDetails.Add(_teamTwoTeamDetails);
                
                return _match;
            }
        }
    }
}