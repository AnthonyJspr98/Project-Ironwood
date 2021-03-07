using System;
using System.Threading;
using System.Threading.Tasks;
using Ironwood.Application.Common.Interfaces;
using Ironwood.Domain.Entities;
using MediatR;

namespace Ironwood.Application.Tournaments.Commands
{
    public class RegisterTournamentCommand : IRequest<Tournament>
    {
        public string  TournamentName { get; set; }

        public class RegisterTournamentCommandHandler : IRequestHandler<RegisterTournamentCommand, Tournament>
        {
            private readonly IIronwoodDbContext dbContext;
            private readonly IMediator mediator;
            private readonly ICurrentUser currentUser;
            public RegisterTournamentCommandHandler(IIronwoodDbContext dbContext, IMediator mediator, ICurrentUser currentUser)
            {
                this.dbContext = dbContext;
                this.mediator = mediator;
                this.currentUser = currentUser;
            }
            public async Task<Tournament> Handle(RegisterTournamentCommand request, CancellationToken cancellationToken)
            {
                Tournament _tourna = new Tournament
                {
                    UID = Guid.NewGuid(),
                    Name = request.TournamentName
                };

                dbContext.Tournaments.Add(_tourna);

                return _tourna;
            }
        }
    }
}