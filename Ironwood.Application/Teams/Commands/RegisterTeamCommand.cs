using System;
using System.Threading;
using System.Threading.Tasks;
using Ironwood.Application.Common.Interfaces;
using Ironwood.Domain.Entities;
using MediatR;

namespace Ironwood.Application.Teams.Commands
{
    public class RegisterTeamCommand : IRequest<Team>
    {       
        public string TeamName { get; set; }
        public string Country { get; set; }

        public class RegisterTeamCommandHandler : IRequestHandler<RegisterTeamCommand, Team>
        {
            private readonly IIronwoodDbContext dbContext;
            private readonly IMediator mediator;
            private readonly ICurrentUser currentUser;
            public RegisterTeamCommandHandler(IIronwoodDbContext dbContext,  IMediator mediator, ICurrentUser currentUser)
            {
                this.dbContext = dbContext;
                this.mediator = mediator;
                this.currentUser = currentUser;
            }
            public async Task<Team> Handle(RegisterTeamCommand request, CancellationToken cancellationToken)
            {
                Team _team = new Team
                {
                    UID = Guid.NewGuid(),
                    Name = request.TeamName,
                    Country = request.Country
                };

                 dbContext.Teams.Add(_team);

                 return _team;
            }
        }
    }
}